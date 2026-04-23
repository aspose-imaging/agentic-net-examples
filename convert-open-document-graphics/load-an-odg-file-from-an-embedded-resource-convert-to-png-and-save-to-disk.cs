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
        // Hard‑coded input path (used only for the existence check as required)
        string inputPath = "Resources/sample.odg";

        // Input path safety check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load ODG image from an embedded resource
        Assembly assembly = Assembly.GetExecutingAssembly();
        // Replace the string below with the actual fully qualified resource name
        const string resourceName = "MyNamespace.Resources.sample.odg";

        using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
        {
            if (resourceStream == null)
            {
                Console.Error.WriteLine($"Embedded resource not found: {resourceName}");
                return;
            }

            // Aspose.Imaging can load the image directly from the stream
            using (OdgImage odgImage = (OdgImage)Image.Load(resourceStream))
            {
                // Hard‑coded output path
                string outputPath = "output/sample.png";

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the image as PNG
                PngOptions pngOptions = new PngOptions();
                odgImage.Save(outputPath, pngOptions);
            }
        }
    }
}