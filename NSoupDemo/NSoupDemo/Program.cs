using NSoup.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace NSoupDemo
{
    /// <summary>
    /// NSoup    可以用类似js语法来解析html，支持net4.0++
    /// github：https://github.com/GeReV/NSoup
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            var html = client.DownloadString("https://blog.csdn.net/czjnoe/article/details/106600070");

            NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(html);
            //根据标签名获取节点
            NSoup.Select.Elements metaElements = doc.GetElementsByTag("meta");
            foreach (var item in metaElements)
            {

            }
            //根据id获取节点
            NSoup.Nodes.Element headClassElements = doc.GetElementById("head");
            //根据class获取节点
            var headIdElements = doc.GetElementsByClass("fm").ToList();
            foreach (var item in headIdElements)
            {

            }
            //根据属性名称获取节点
            List<Element> attributeNameElements = doc.GetElementsByAttribute("class").ToList();

            //根据属性值获取节点
            List<Element> attributeValueElements = doc.GetElementsByAttributeValue("id", "su").ToList();

            //根据jQuery选择器获取节点
            var selectElments =doc.Select("#head").ToList();
        }
    }
}
