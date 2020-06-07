using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace html_agility_packDemo
{
    /// <summary>
    /// html_agility_pack:  网络爬虫利器, 解析Html
    /// github:https://github.com/zzzprojects/html-agility-pack
    /// 官方文档：https://html-agility-pack.net/documentation
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //注意==>"//"表示从根节点开始查找，两个斜杠‘//’表示查找所有childnodes；一个斜杠'/'表示只查找第一层的childnodes;点斜杠"./"表示从当前结点而不是根结点开始查找。

            //从web读取
            {
                string url = "http://www.baidu.com";
                HtmlWeb web = new HtmlWeb();
                //从url中加载
                HtmlDocument doc = web.Load(url);
                //获得title标签节点，其子标签下的所有节点也在其中
                HtmlNode headNode = doc.DocumentNode.SelectSingleNode("//title");
                //获得title标签中的内容
                string Title = headNode.InnerText;

                //获得class为s_tab_inner下，标签为a的所有节点
                HtmlNodeCollection classNode = doc.DocumentNode.SelectNodes("//div[@id='head']");
                //遍历节点
                foreach (var item in classNode)
                {
                    //从当前节点开启查找，id为ul的节点
                   var collectionNodes= item.SelectNodes("./div[@id='u1']");
                }

                //获得id为head下的所有节点
                HtmlNodeCollection idNode = doc.DocumentNode.SelectNodes("//div[@class='s_tab_inner']/a");
                //遍历idNode
                foreach (var item in idNode)
                {
                    var OuterHtml=item.OuterHtml;//当前节点的html源码
                    var InnerHtml = item.InnerHtml;//当前节点的子节点的html源码
                    var InnerText = item.InnerText;//当前节点文本值

                    //获得标签属性为href的值
                    string aValue = item.Attributes["href"]?.Value;
                    //获得标签内的内容
                    string aInterText = item.InnerText;//获取文本值

                    Console.WriteLine("属性值：" + aValue + "\t" + "标签内容:" + aInterText);
                }


                //获得id为head下的第一个a节点
                HtmlNode idSingleNode = doc.DocumentNode.SelectSingleNode("//div[@class='s_tab_inner']/a");
                //获取子节点
                HtmlNodeCollection s_tab_innerChildCollection = idSingleNode.ChildNodes;

               
            }
            //从文件读取
            {
                var doc = new HtmlDocument();
                doc.Load("filePath");//文件路径
            }
            //字符串读取
            {
                var doc = new HtmlDocument();
                doc.LoadHtml("字符串");
            }
        }
    }
}
