using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Item {

	[XmlAttribute("stage")]
	public string stage;

	[XmlElement("Sound")]
	public string sound;

	[XmlElement("Choice1")]
	public string choice1;

	[XmlElement("Choice2")]
	public string choice2;

	[XmlElement("Choice3")]
	public string choice3;

	[XmlElement("Answer")]
	public int answer;

	[XmlElement("Anim")]
	public string anim;




}
