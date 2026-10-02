// HOW-TO: Apply Custom Convolution Filter to SVG Using C# and Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Xml;

namespace SvgFilterApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.svg";
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = "output.svg";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                XmlDocument doc = new XmlDocument();
                doc.Load(inputPath);

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("svg", "http://www.w3.org/2000/svg");

                XmlElement defs = doc.DocumentElement.SelectSingleNode("svg:defs", nsmgr) as XmlElement;
                if (defs == null)
                {
                    defs = doc.CreateElement("defs", doc.DocumentElement.NamespaceURI);
                    doc.DocumentElement.InsertBefore(defs, doc.DocumentElement.FirstChild);
                }

                XmlElement filter = doc.CreateElement("filter", doc.DocumentElement.NamespaceURI);
                string filterId = "customConvolve";
                filter.SetAttribute("id", filterId);

                XmlElement feConvolve = doc.CreateElement("feConvolveMatrix", doc.DocumentElement.NamespaceURI);
                feConvolve.SetAttribute("order", "3");

                double center = 0.5;
                double surround = 0.125;
                double sum = center + 8 * surround; // 1.5
                double normCenter = center / sum;   // 0.333333...
                double normSurround = surround / sum; // 0.083333...

                string kernel = $"{normSurround} {normSurround} {normSurround} " +
                                $"{normSurround} {normCenter} {normSurround} " +
                                $"{normSurround} {normSurround} {normSurround}";
                feConvolve.SetAttribute("kernelMatrix", kernel);
                feConvolve.SetAttribute("preserveAlpha", "true");

                filter.AppendChild(feConvolve);
                defs.AppendChild(filter);

                doc.DocumentElement.SetAttribute("filter", $"url(#{filterId})");

                doc.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to blur or sharpen an SVG graphic by applying a custom 3x3 convolution kernel in a .NET application.
 * 2. When you want to embed a reusable filter definition directly into an SVG file for consistent rendering across browsers.
 * 3. When you must normalize kernel weights to maintain the image’s overall brightness after applying the filter.
 * 4. When you are programmatically generating SVG assets and need to ensure the filter is added only if a <defs> section is missing.
 * 5. When you need to automate SVG preprocessing in a build pipeline, such as applying a subtle smoothing effect before conversion to raster formats.
 */
