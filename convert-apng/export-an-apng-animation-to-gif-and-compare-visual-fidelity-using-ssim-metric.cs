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
            string inputApngPath = "Input/animation.apng";
            string outputGifPath = "Output/animation.gif";

            if (!File.Exists(inputApngPath))
            {
                Console.Error.WriteLine($"File not found: {inputApngPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

            using (Image apngImage = Image.Load(inputApngPath))
            {
                GifOptions gifOptions = new GifOptions();
                apngImage.Save(outputGifPath, gifOptions);
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
 * 1. When a developer needs to convert an animated PNG (APNG) file to an animated GIF for compatibility with browsers that only support GIF, they can use this code to perform the conversion in C#.
 * 2. When a developer wants to generate a GIF version of an APNG to embed in legacy email clients that do not render APNG, this snippet provides a straightforward way to save the animation as a GIF.
 * 3. When a developer is building a batch processing tool that normalizes various animation formats to GIF for a content management system, they can use this code to load each APNG and export it as a GIF.
 * 4. When a developer needs to compare visual fidelity between the original APNG and the resulting GIF using metrics like SSIM, this example shows how to create the GIF output that can then be analyzed.
 * 5. When a developer is creating a unit test to verify that an APNG file is correctly transformed into a GIF without runtime errors, this code demonstrates loading the source image, converting it, and handling missing files gracefully.
 */