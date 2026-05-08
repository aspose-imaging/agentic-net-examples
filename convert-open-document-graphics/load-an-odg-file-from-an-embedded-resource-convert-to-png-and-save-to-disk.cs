using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path (used only for existence check as per safety rules)
            string inputPath = "Resources/sample.odg";

            // Verify the input file exists; if not, report and exit
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load ODG file from embedded resource
            Assembly assembly = Assembly.GetExecutingAssembly();
            // Adjust the resource name to match the actual namespace and folder structure
            string resourceName = "MyNamespace.Resources.sample.odg";

            using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                {
                    Console.Error.WriteLine($"Embedded resource not found: {resourceName}");
                    return;
                }

                // Load the ODG image from the stream and cast to OdgImage
                using (OdgImage odgImage = (OdgImage)Image.Load(resourceStream))
                {
                    // Hardcoded output path
                    string outputPath = "output/sample.png";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image as PNG
                    PngOptions pngOptions = new PngOptions();
                    odgImage.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}