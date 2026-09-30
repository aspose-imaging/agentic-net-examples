// HOW-TO: Asynchronously Convert CMX Files To JPEG In C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            await ConvertCmxToJpegAsync(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ConvertCmxToJpegAsync(string inputPath, string outputPath)
    {
        await Task.Run(() =>
        {
            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
            }
        });
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application needs to load legacy CMX vector drawings and display them as JPEG thumbnails without freezing the UI.
 * 2. When a web service processes batch uploads of CorelDRAW CMX files and must generate JPEG previews on a background thread.
 * 3. When an automated reporting tool converts CMX diagrams to JPEG images for inclusion in PDF reports while keeping the main thread responsive.
 * 4. When a mobile app using Xamarin loads CMX assets and saves them as JPEGs without blocking user interactions.
 * 5. When a server‑side job converts user‑submitted CMX files to JPEG for storage in a content management system while leveraging async/await for scalability.
 */
