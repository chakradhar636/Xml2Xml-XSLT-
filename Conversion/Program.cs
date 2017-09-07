using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

public class Sample
{

    public static void Main()
    {
        string inputFile = @"C:\Users\donuric\Documents\Visual Studio 2015\Projects\Conversion\Conversion\XMLFile1.xml";
        string xsltFile = @"C:\Users\donuric\Documents\Visual Studio 2015\Projects\Conversion\Conversion\XSLTFile1.xslt";
        string outputFile = @"C:\Users\donuric\Desktop\new.xml";
        // Create the XslCompiledTransform and load the stylesheet.
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(xsltFile);

        // Create the XsltArgumentList.
        XsltArgumentList xslArg = new XsltArgumentList();

        // Create a parameter which represents the current date and time.
        DateTime d = DateTime.Now;
        xslArg.AddParam("date", "", d.ToString());

        // Transform the file.
        using (XmlWriter w = XmlWriter.Create(outputFile))
        {
            xslt.Transform(inputFile, xslArg, w);
        }   
    }
}