// HOW-TO: Convert Multi Page TIFF to Animated APNG with Infinite Loop in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.tif";
            string outputPath = "Output/animation.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                var apngOptions = new ApngOptions
                {
                    NumPlays = 0
                };
                tiffImage.Save(outputPath, apngOptions);
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
 * 1. When you need to display a multi‑page scanned document as a looping animation on a website, you can convert the TIFF to an APNG with infinite repeats using C#.
 * 2. When creating a product showcase that cycles through several high‑resolution images without user interaction, this code turns the TIFF frames into a continuously playing APNG.
 * 3. When generating animated icons from a multi‑page TIFF for a desktop application, the snippet produces an APNG that loops forever.
 * 4. When automating a batch process that converts archival TIFF files into lightweight animated PNGs for mobile apps, the code ensures the animation repeats endlessly.
 * 5. When building a reporting tool that visualizes step‑by‑step screenshots stored in a TIFF as a seamless looping animation, this example creates the required APNG in .NET.
 */
