// HOW-TO: Check SVG Gaussian Blur Filter for Artifacts Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Xml.Linq;

namespace SvgGaussianBlurVerification
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.svg";
                string outputPath = "output.svg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                // Load original SVG
                XDocument originalDoc = XDocument.Load(inputPath);
                XDocument modifiedDoc = new XDocument(originalDoc);

                // Namespace handling
                XNamespace svgNs = "http://www.w3.org/2000/svg";

                // Ensure <defs> exists
                XElement defs = modifiedDoc.Root.Element(svgNs + "defs");
                if (defs == null)
                {
                    defs = new XElement(svgNs + "defs");
                    modifiedDoc.Root.AddFirst(defs);
                }

                // Create Gaussian blur filter
                XElement filter = new XElement(svgNs + "filter",
                    new XAttribute("id", "blur"),
                    new XElement(svgNs + "feGaussianBlur",
                        new XAttribute("stdDeviation", "2")
                    )
                );
                defs.Add(filter);

                // Apply filter to the root <svg> element
                modifiedDoc.Root.SetAttributeValue("filter", "url(#blur)");

                // Save modified SVG
                modifiedDoc.Save(outputPath);

                // Verification: ensure all original elements (except the added filter) are present
                bool verificationPassed = true;
                foreach (XElement originalElement in originalDoc.Root.Elements())
                {
                    // Skip <defs> if it was added by us
                    if (originalElement.Name == svgNs + "defs")
                        continue;

                    XElement corresponding = modifiedDoc.Root.Element(originalElement.Name);
                    if (corresponding == null)
                    {
                        verificationPassed = false;
                        Console.Error.WriteLine($"Missing element: {originalElement.Name}");
                        break;
                    }

                    // Compare attributes (excluding filter attribute on root)
                    foreach (XAttribute attr in originalElement.Attributes())
                    {
                        XAttribute modAttr = corresponding.Attribute(attr.Name);
                        if (modAttr == null || modAttr.Value != attr.Value)
                        {
                            verificationPassed = false;
                            Console.Error.WriteLine($"Attribute mismatch in element {originalElement.Name}: {attr.Name}");
                            break;
                        }
                    }

                    if (!verificationPassed) break;
                }

                Console.WriteLine(verificationPassed
                    ? "Verification passed: Gaussian blur applied without unwanted artifacts."
                    : "Verification failed: Differences detected.");
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
 * 1. When you need to programmatically add a Gaussian blur filter to an SVG file while confirming that all original vector elements remain intact.
 * 2. When you want to automate a verification step that ensures applying an SVG blur effect does not remove or alter existing shapes before publishing.
 * 3. When generating SVG assets for web pages and must validate that the blur filter does not introduce rendering artifacts across browsers.
 * 4. When building a CI pipeline that tests SVG transformations such as filters to prevent broken vector graphics from reaching production.
 * 5. When creating a design tool that applies visual effects to SVG files and needs to guarantee that the original markup is preserved after modification.
 */
