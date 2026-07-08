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
            // Hardcoded input path (used only for existence check)
            string inputPath = "Resources/sample.odg";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output path
            string outputPath = "output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load ODG from embedded resource
            var assembly = Assembly.GetExecutingAssembly();
            // Adjust the resource name to match the actual embedded resource
            using (Stream resourceStream = assembly.GetManifestResourceStream("MyApp.Resources.sample.odg"))
            {
                if (resourceStream == null)
                {
                    Console.Error.WriteLine("Embedded resource not found.");
                    return;
                }

                // Load the image from the stream
                using (Image image = Image.Load(resourceStream))
                {
                    // Save as PNG (format inferred from file extension)
                    image.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application needs to display vector graphics from an OpenDocument Drawing (ODG) file bundled as an embedded resource, it can load the ODG, convert it to PNG, and save it for rendering in UI controls.
 * 2. When generating thumbnails for ODG documents stored inside a .NET assembly, developers can use this code to extract the embedded file, rasterize it to PNG, and write the thumbnail to a cache folder.
 * 3. When a reporting service must embed ODG diagrams into PDF or HTML reports, the service can convert the embedded ODG to PNG on the fly and store the PNG for inclusion in the final output.
 * 4. When building a batch conversion tool that processes ODG templates packaged with the application, the tool can load each template from resources, convert to PNG, and save the images for use by downstream image processing pipelines.
 * 5. When creating a cross‑platform mobile app that ships ODG assets inside the assembly and needs a raster image for display on devices that only support PNG, this code enables loading the ODG resource, converting it to PNG, and persisting it to the device storage.
 */