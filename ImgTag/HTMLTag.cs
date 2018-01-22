/*
 * Creato da SharpDevelop.
 * Utente: salvatore
 * Data: 18/06/2013
 * Ora: 11.23
 * 
 * Per modificare questo modello usa Strumenti | Opzioni | Codice | Modifica Intestazioni Standard
 */
using System;
using System.Text;
using System.Collections.Generic;

namespace ImgTag
{
	/// <summary>
	/// Description of HTMLTag.
	/// </summary>
	/// 
	
	
	[Serializable()]
public class InvalidHTMLTagException : System.Exception
{
    public InvalidHTMLTagException() : base() { }
    public InvalidHTMLTagException(string message) : base(message) { }
    public InvalidHTMLTagException(string message, System.Exception inner) : base(message, inner) { }

    // A constructor is needed for serialization when an 
    // exception propagates from a remoting server to the client.  
    protected InvalidHTMLTagException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) { }
}
	
	
	public class HTMLTag
	{
		private string _tag;
		private Dictionary<string,string> _attr=new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		
		public HTMLTag(string str)
		{
			StringBuilder sb=new StringBuilder(str);
			if (sb.Length==0)
			{
				throw new InvalidHTMLTagException();
			}
			else
			{
				if(sb[sb.Length-1]!='>')
				{
					throw new InvalidHTMLTagException();
				}
				else
				{
					sb.Remove(sb.Length-1,1);
					if(sb[sb.Length-1]=='/')
					{
						sb.Remove(sb.Length-1,1);
					}
					
					if(sb[0]!='<')
					{
						throw new InvalidHTMLTagException();
					}
					else
					{
						sb.Remove(0,1);
						string s=sb.ToString();
						int sp=s.IndexOf(' ');
						if(sp<=0){
						this._tag=s;
						return;}
						else
						{
							this._tag=s.Substring(0,sp);
							sb.Remove(0,sp);
							s=sb.ToString();
							char [] separator={' ','='};
							var tokens=s.Split(separator);
							
							if(tokens.Length>0)
							{
							
								bool b=true;
								int i=0;
								while(b)
								{
									if(tokens[i]=="")i++;
									if((i+1)>=tokens.Length)break;
									this._attr[tokens[i]]=(tokens[i+1]).Trim('\"');
									i+=2;
									if(i>=tokens.Length)b=false;
								}
							}
							  
						}
					}
					
				}
			}
		}
		
		public string Tag
		{
			get
			{
				return this._tag;
			}
		}
		
		public string getValue(string attribute)
		{
			if(_attr.ContainsKey(attribute))return _attr[attribute];
			return "";
		}
		
		public void setValue(string attribute,string val)
		{
			 _attr[attribute]=val;
		}
		
		
		public int attributesCount
		{
			get
			{
				return _attr.Count;
			}
		}
		
		public bool CompareTag(string str) 
		{
			return _tag.Equals(str, StringComparison.InvariantCultureIgnoreCase);
		}
		
		public string Content
		{
			get
			{
				StringBuilder sb=new StringBuilder("<"+_tag+" ");
				foreach(var key in _attr.Keys)
				{
					sb.Append(key+"=\""+_attr[key]+"\" ");
				}
				sb.Append("/>");
				return sb.ToString();
			}
		}
		
	}
}
