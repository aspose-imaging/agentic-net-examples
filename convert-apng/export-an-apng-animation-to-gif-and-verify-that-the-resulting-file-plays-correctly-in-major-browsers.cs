using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputPath = "output/output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load APNG and save as GIF
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new GifOptions());
            }

            // Verify that the saved GIF contains multiple frames (animation)
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"Failed to create output file: {outputPath}");
                return;
            }

            using (Image gif = Image.Load(outputPath))
            {
                if (gif is IMultipageImage multi && multi.PageCount > 1)
                {
                    Console.WriteLine("GIF animation verified: contains multiple frames.");
                }
                else
                {
                    Console.WriteLine("GIF does not contain multiple frames.");
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
 * 1. When a web developer needs to convert an animated PNG (APNG) uploaded by users into a GIF that can be displayed in browsers that do not support APNG, such as older versions of Internet Explorer or Safari.
 * 2. When a mobile‑app backend must generate lightweight animated previews from high‑resolution APNG assets for faster loading on low‑bandwidth connections, using C# and Aspose.Imaging to produce GIF files.
 * 3. When an e‑learning platform wants to ensure that animated diagrams created in APNG format are compatible with all major browsers by automatically converting them to GIF and confirming the animation contains multiple frames.
 * 4. When a digital‑marketing system processes user‑submitted APNG banners and needs to store them as GIFs for email campaigns, verifying the conversion succeeded before sending.
 * 5. When a content‑management system integrates a C# service that batch‑processes APNG icons into GIFs for legacy browsers and validates the output by checking the frame count with Aspose.Imaging.
 */