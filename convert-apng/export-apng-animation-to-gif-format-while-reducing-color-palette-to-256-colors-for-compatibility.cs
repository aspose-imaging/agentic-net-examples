// HOW-TO: Convert APNG Animation to 256‑Color GIF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.apng";
            string outputPath = "output.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the APNG animation
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF saving options to limit palette to 256 colors
                var gifOptions = new GifOptions
                {
                    DoPaletteCorrection = true,   // Analyze source colors and build optimal palette
                    ColorResolution = 7           // 2^(7+1) = 256 colors
                };

                // Save the animation as a GIF file
                image.Save(outputPath, gifOptions);
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
 * 1. When you need to display an animated PNG on platforms that only support GIF, you can convert it to a GIF with a limited 256‑color palette.
 * 2. When preparing assets for email newsletters where GIF is the only supported animation format, this code transforms APNG files while ensuring compatibility.
 * 3. When optimizing web content for older browsers that cannot render APNG, you can generate a GIF version with controlled color depth to reduce file size.
 * 4. When integrating image processing into a C# application that receives APNG uploads, you can automatically convert them to GIF for storage or further processing.
 * 5. When creating a batch conversion tool to standardize animation formats across a media library, this snippet shows how to load APNG and save it as a 256‑color GIF.
 */
