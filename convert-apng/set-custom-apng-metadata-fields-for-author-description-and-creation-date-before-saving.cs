using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
                {
                    apng.RemoveAllFrames();
                    apng.AddFrame(sourceImage);
                    apng.Save();
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
 * 1. When a developer needs to embed author, description, and creation date metadata into an animated PNG (APNG) for compliance with digital asset management systems, they can use Aspose.Imaging for .NET to set these fields before saving the file.
 * 2. When generating APNG files for an e‑learning platform where each animation must carry provenance information such as the content creator’s name, a brief description, and the timestamp of creation, the code can be extended to add custom metadata.
 * 3. When exporting animated charts from a C# reporting tool and the client requires the APNG to include metadata for version tracking and audit trails, developers can set the author, description, and creation date using Aspose.Imaging before calling Save().
 * 4. When creating marketing GIF‑style animations that are saved as APNG and need to be searchable in a media library by author and description, adding custom metadata fields ensures the images are indexed correctly.
 * 5. When automating a CI/CD pipeline that produces APNG assets and the build process must record the build number and build date in the image metadata for later debugging, developers can programmatically assign these values prior to saving the APNG.
 */