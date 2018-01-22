using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NppPluginNET;

namespace ImgTag
{
    class Main
    {
        #region " Fields "
        internal const string PluginName = "ImgTag";
        static string iniFilePath = null;
        static bool someSetting = false;
        static int idMyDlg = -1;
        static Bitmap tbBmp = Properties.Resources.image;
        static Bitmap tbBmp_tbTab = Properties.Resources.image;
        static Icon tbIcon = null;
        #endregion

        #region " StartUp/CleanUp "
        internal static void CommandMenuInit()
        {
                StringBuilder sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
                Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
                iniFilePath = sbIniFilePath.ToString();
                if (!Directory.Exists(iniFilePath)) Directory.CreateDirectory(iniFilePath);
                iniFilePath = Path.Combine(iniFilePath, PluginName + ".ini");
                someSetting = (Win32.GetPrivateProfileInt("ImgTag", "ImgTag", 0, iniFilePath) != 0);

                PluginBase.SetCommand(0, "Insert Image", insert_image, new ShortcutKey(false, true, false, Keys.I));
                PluginBase.SetCommand(1, "---", null);
                PluginBase.SetCommand(2, "Update Image Size", update_image, new ShortcutKey(false, true, false, Keys.U));
                PluginBase.SetCommand(3, "Resize Image", resize_image, new ShortcutKey(false, true, false, Keys.R));
                PluginBase.SetCommand(4, "Rename Image", rename_image, new ShortcutKey(false, true, false, Keys.N));
                PluginBase.SetCommand(5, "---", null);
                PluginBase.SetCommand(6, "Show Image", show_image, new ShortcutKey(false, true, false, Keys.S));
                PluginBase.SetCommand(7, "---", null);
                PluginBase.SetCommand(8, "Image Gallery", image_gallery, new ShortcutKey(false, true, false, Keys.G));
                PluginBase.SetCommand(9, "---", null);
                PluginBase.SetCommand(10, "About", about);
                idMyDlg = 0;
        }

        internal static void SetToolBarIcon()
        {
            toolbarIcons tbIcons = new toolbarIcons();
            tbIcons.hToolbarBmp = tbBmp.GetHbitmap();
            IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
            Marshal.StructureToPtr(tbIcons, pTbIcons, false);
            Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[idMyDlg]._cmdID, pTbIcons);
            Marshal.FreeHGlobal(pTbIcons);
        }

        internal static void PluginCleanUp()
        {
            Win32.WritePrivateProfileString("ImgTag", "ImgTag", someSetting ? "1" : "0", iniFilePath);
        }
        #endregion

        #region " Menu functions "
        static void insert_image()
        {
            string cdir = currentDir();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = cdir;
            openFileDialog1.Filter = "image files|*.jpg;*.JPG;*.jpeg;*.JPEG;*.png;*.PNG;*.gif;*.GIF;*.bmp;*.BMP";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var filename in openFileDialog1.FileNames)
                {

                    Bitmap bmp;

                    try
                    {
                        bmp = (Bitmap)Bitmap.FromFile(filename);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("It's impossible to load the selected image!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string path = "<img src=\"" + relPath(cdir, filename) + "\" width=\"" + bmp.Width.ToString() + "\" height=\"" + bmp.Height.ToString() + "\" border=\"0\" alt=\"\" />\r\n";
                    Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_REPLACESEL, 0, path);
                    bmp.Dispose();
                }
            }
        }


        static void update_image()
        {
            string seltext = getSelText();
            try
            {
                var tag = new HTMLTag(seltext);
                if (tag.CompareTag("img"))
                {
                    string src = tag.getValue("src");
                    if (src != "")
                    {
                        string path = currentDir() + Path.DirectorySeparatorChar + src.Replace('/', Path.DirectorySeparatorChar);
                        try
                        {
                            using (Bitmap bmp = (Bitmap)Bitmap.FromFile(path))
                            {
                                tag.setValue("width", bmp.Width.ToString());
                                tag.setValue("height", bmp.Height.ToString());
                                Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_REPLACESEL, 0, tag.Content);
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("It's impossible to load the selected image!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (InvalidHTMLTagException)
            { MessageBox.Show("The selected tag is not an img tag valid!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        static void resize_image()
        {
            string seltext = getSelText();
            try
            {
                var tag = new HTMLTag(seltext);
                if (tag.CompareTag("img"))
                {
                    string src = tag.getValue("src");
                    if (src != "")
                    {
                        string path = currentDir() + Path.DirectorySeparatorChar + src.Replace('/', Path.DirectorySeparatorChar);
                        try
                        {
                            using (Bitmap bmp = LoadBitmap(path))
                            {
                                int w, h;
                                ResizingDialog rd = new ResizingDialog();
                                int imageW = (Int32.TryParse(tag.getValue("width"), out w)) ? w : bmp.Width;
                                int imageH = (Int32.TryParse(tag.getValue("height"), out h)) ? h : bmp.Height;
                                rd.CalculateAspectRatio(imageW, imageH);
                                rd.ImageName = src;
                                if (rd.ShowDialog() == DialogResult.OK)
                                {

                                    if (rd.RealResizing)
                                    {
                                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                                        saveFileDialog1.Title = "Save As...";
                                        saveFileDialog1.Filter = "image files|*.jpg;*.JPG;*.jpeg;*.JPEG;*.png;*.PNG;*.gif;*.GIF;*.bmp;*.BMP";
                                        saveFileDialog1.RestoreDirectory = true;
                                        saveFileDialog1.InitialDirectory = currentDir();
                                        saveFileDialog1.OverwritePrompt = true;
                                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                        {
                                            int newWidth = rd.ImageWidth;
                                            int newHeight = rd.ImageHeight;
                                            using (Bitmap newImage = new Bitmap(newWidth, newHeight))
                                            {
                                                using (Graphics gr = Graphics.FromImage(newImage))
                                                {
                                                    gr.SmoothingMode = SmoothingMode.HighQuality;
                                                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                                    gr.DrawImage(bmp, new Rectangle(0, 0, newWidth, newHeight));
                                                }
                                                try
                                                {
                                                    newImage.Save(saveFileDialog1.FileName);
                                                    tag.setValue("width", newWidth.ToString());
                                                    tag.setValue("height", newHeight.ToString());
                                                    tag.setValue("src", relPath(currentDir(), saveFileDialog1.FileName));
                                                    Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_REPLACESEL, 0, tag.Content);
                                                }
                                                catch (Exception)
                                                {
                                     
                                                    newImage.Dispose();
                                                    MessageBox.Show("It's impossible to save the image!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }

                                            }

                                        }
                                    }
                                    else
                                    {
                                        tag.setValue("width", rd.ImageWidth.ToString());
                                        tag.setValue("height", rd.ImageHeight.ToString());
                                        Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_REPLACESEL, 0, tag.Content);
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("It's impossible to load the selected image!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (InvalidHTMLTagException)
            { MessageBox.Show("The selected tag is not an img tag valid!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        static void rename_image()
        {
            string seltext = getSelText();
            try
            {
                var tag = new HTMLTag(seltext);
                if (tag.CompareTag("img"))
                {
                    string src = tag.getValue("src");
                    if (src != "")
                    {
                        string path = currentDir() + Path.DirectorySeparatorChar + src.Replace('/', Path.DirectorySeparatorChar);
                        var arraypath = path.Split(Path.DirectorySeparatorChar);
                        InputBox ibox = new InputBox("Please, insert the new name for the image \"" + arraypath[arraypath.Length - 1] + "\"");
                        if (ibox.ShowDialog() != DialogResult.OK) return;
                        if (ibox.Input == "")
                        {
                            MessageBox.Show("You have not inserted a valid name!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string[] apath = new string[arraypath.Length - 1];

                        for (int i = 0; i < (arraypath.Length - 1); ++i)
                        {
                            apath[i] = arraypath[i];
                        }

                        try
                        {
                            string p = "";
                            if (apath.Length > 0) p = String.Join(new String(Path.DirectorySeparatorChar, 1), apath) + Path.DirectorySeparatorChar;
                            string newpath = p + ibox.Input;
                            System.IO.File.Move(path, newpath);
                            tag.setValue("src", relPath(currentDir(),newpath));
                            Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_REPLACESEL, 0, tag.Content);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("It's impossible to rename the selected file with the name \"" + ibox.Input + "\"!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch (InvalidHTMLTagException)
            { MessageBox.Show("The selected tag is not an img tag valid!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        static void show_image()
        {
            string seltext = getSelText();
            try
            {
                var tag = new HTMLTag(seltext);
                if (tag.CompareTag("img"))
                {
                    string src = tag.getValue("src");
                    if (src != "")
                    {
                        string path = currentDir() + Path.DirectorySeparatorChar + src.Replace('/', Path.DirectorySeparatorChar);
                        try
                        {
                            Bitmap bmp = (Bitmap)Bitmap.FromFile(path);

                            ToolWindow twin = new ToolWindow(bmp);
                            if (bmp.Width > bmp.Height)
                            {
                                twin.Width = (bmp.Width <= 600) ? bmp.Width : 600;
                                twin.Height = (int)(((double)bmp.Height / (double)bmp.Width) * (double)twin.Width);
                            }
                            else
                            {
                                twin.Height = ((bmp.Height <= 600) ? bmp.Height : 600)+30;
                                twin.Width = (int)(((double)bmp.Width / (double)bmp.Height) * (double)twin.Height);
                            }
                            Graphics g = twin.CreateGraphics();
                            Rectangle rect = new Rectangle(0, 0, twin.Width, twin.Height-30);
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            g.DrawImage(bmp, rect);
                            g.Dispose();
                            twin.ShowDialog();


                        }
                        catch (Exception)
                        {
                            MessageBox.Show("It's impossible to load the selected image!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (InvalidHTMLTagException)
            { MessageBox.Show("The selected tag is not an img tag valid!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        static void image_gallery()
        {
            ImgGalleryDlg igd = new ImgGalleryDlg(currentDir());
            if (igd.ShowDialog() == DialogResult.OK)
            {
                string filters = "*.jpg|*.jpeg|*.png|*.gif|*.bmp";
                var thumbnails = getFiles(igd.ThumbnailsFolder, filters, SearchOption.TopDirectoryOnly);
                var fullSizeImages = getFiles(igd.FullSizeImagesFolder, filters, SearchOption.TopDirectoryOnly);
                if (thumbnails.Length != fullSizeImages.Length)
                {
                    MessageBox.Show("The thumbnails number must be equal to the full size images number!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (thumbnails.Length == 0)
                {
                    MessageBox.Show("No images in a selected folder", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (igd.Columns == 0)
                {
                    MessageBox.Show("The columns number must be a valid number!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string cdir = currentDir();
                StringBuilder content=new StringBuilder("<table border=\"0\">\r\n");
		        int td=0;
		        string strclass=(igd.LinkClass!="")?"class=\""+igd.LinkClass+"\" ":"";
		        string strrel=(igd.LinkRel!="")?"rel=\""+igd.LinkRel+"\" ":"";
		        for( int i=0; i<thumbnails.Length;i++)
		        {
			        td++;
			        if(td==1)content.Append( "<tr>\r\n");
			        string thumbname=thumbnails[i];
			        string imgtag="<img src=\""+relPath(cdir,thumbname)+"\" alt=\"\" "+image_size(thumbname)+" border=\"0\" />";
			        string fImgname=fullSizeImages[i];
			        content.Append( "<td align=\"center\"><a href=\""+relPath(cdir,fImgname)+"\" "+strclass+strrel+">"+imgtag+"</a></td>\r\n");
		            if (td==igd.Columns)
		            {
			            content.Append( "</tr>\n");
			            td=0;
		            }
		            else
		            {
			            if(i==(thumbnails.Length-1))
			            {
				            for(int r=0;r<(igd.Columns-td);r++)
				            {
					            content.Append( "<td>&nbsp;</td>\n");
				            }
				            content.Append( "</tr>\n");
			            }
		            }
	            }
	            content.Append( "</table>");
                Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_REPLACESEL, 0, content);
            }
        }


        static void about()
        {
            var adlg = new AboutDlg();
            adlg.ShowDialog();
        }


        static string currentDir()
        {
            NppMsg msg = NppMsg.NPPM_GETCURRENTDIRECTORY;
            StringBuilder path = new StringBuilder(Win32.MAX_PATH);
            Win32.SendMessage(PluginBase.nppData._nppHandle, msg, 0, path);
            return path.ToString();
        }

        static string relPath(string starting_path, string filepath)
        {
            if (starting_path != "")
            {
                var uri1 = new Uri(starting_path + "\\");
                var uri2 = new Uri(filepath);
                return Uri.UnescapeDataString(uri1.MakeRelativeUri(uri2).ToString());
            }
            int x = filepath.IndexOf(':');
            if (x > -1 && (x+1)<filepath.Length ) filepath = "file://"+filepath.Substring(x + 1).Replace(Path.DirectorySeparatorChar,'/');

            return filepath;
        }

        internal static string getSelText()
        {
            var scintilla = PluginBase.GetCurrentScintilla();
            string text = "";
            int start = (int)Win32.SendMessage(scintilla, SciMsg.SCI_GETSELECTIONNSTART, 0, 0);
            int end = (int)Win32.SendMessage(scintilla, SciMsg.SCI_GETSELECTIONNEND, 0, 0);
            int length = end - start + 1;
            if (length > 1)
            {
                StringBuilder sb = new StringBuilder(length);
                Win32.SendMessage(scintilla, SciMsg.SCI_GETSELTEXT, 0, sb);
                text = sb.ToString();
            }
            return text;
        }

        static Bitmap LoadBitmap(string filePath)
        {
            Bitmap image;
            using (Bitmap b = new Bitmap(filePath))
            {
                image = new Bitmap(b.Width, b.Height, b.PixelFormat);
                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawImage(b, Point.Empty);
                    g.Flush();
                }
            }
            return image;
        }

        private static string image_size(string filePath)
        {
            string swidth="", sheight="";
            try
            {
                using (Bitmap b = new Bitmap(filePath))
                {
                    swidth=b.Width.ToString();
                    sheight = b.Height.ToString();
                }
            }
            catch (Exception) { }
            return "width=\""+swidth+"\" height=\""+sheight+"\"";
        }

        private static string[] getFiles(string sourceFolder, string filters, System.IO.SearchOption searchOption)
        {
            string[] ext= filters.Split('|');
            ArrayList alist = new ArrayList();
            foreach (string found in ext)
            {
                alist.AddRange (Directory.GetFiles(sourceFolder, found,searchOption));
            }
            alist.Sort();
            return (string[])alist.ToArray(typeof(string));
        }
        
        #endregion
    }
}