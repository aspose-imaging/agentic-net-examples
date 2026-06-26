using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/animation.apng";
            string outputPath = "Output/animation.gif";

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

            // Verify the saved GIF is animated (has multiple frames)
            using (GifImage gif = (GifImage)Image.Load(outputPath))
            {
                if (gif.PageCount > 1)
                {
                    Console.WriteLine("GIF animation saved successfully with multiple frames.");
                }
                else
                {
                    Console.WriteLine("GIF saved, but it does not contain multiple frames.");
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
 * 1. When a web developer needs to convert an animated PNG (APNG) into a GIF that works in legacy browsers, this C# code with Aspose.Imaging performs the conversion and verifies the animation frames.
 * 2. When an e‑learning platform wants to reuse existing APNG tutorial animations in email newsletters that only support GIF, the snippet programmatically transforms the files and checks that the resulting GIF contains multiple frames.
 * 3. When a content management system automatically processes user‑uploaded assets and must ensure animated images are compatible with all major browsers, this code can convert APNG uploads to GIF and validate the animation integrity.
 * 4. When a digital marketing agency prepares a batch of product showcase animations for social media platforms that require GIF format, they can employ this routine to convert each APNG file and confirm the output plays correctly across browsers.
 * 5. When a QA engineer needs to automate testing of image conversion pipelines, this example provides a straightforward way to load an APNG, save it as a GIF using Aspose.Imaging, and programmatically verify that the saved GIF is animated by inspecting its page count.
 */