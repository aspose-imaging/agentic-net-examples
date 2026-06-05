using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = @"C:\temp\output.jp2";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions
            int width = 200;
            int height = 100;

            // Create a JPEG2000 image
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(width, height))
            {
                // Prepare raw ARGB pixel data (filled with red color)
                int[] pixels = new int[width * height];
                int redArgb = Aspose.Imaging.Color.Red.ToArgb();
                for (int i = 0; i < pixels.Length; i++)
                {
                    pixels[i] = redArgb;
                }

                // Write pixel data to the image
                jpeg2000Image.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);

                // Save the image to file with default JPEG2000 options
                jpeg2000Image.Save(outputPath, new Jpeg2000Options());
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
 * 1. When a developer needs to programmatically create a JPEG2000 image from raw ARGB pixel buffers—for example, to store a generated graphic in a lossless, high‑dynamic‑range format—they can use this C# snippet to define the width, height, fill the pixel array, and save the file with Jpeg2000Options.
 * 2. When integrating a .NET application with a medical imaging workflow that requires JPEG2000 files with precise color space handling, this code demonstrates how to construct the image from pixel data and ensure correct color representation.
 * 3. When building a server‑side image processing service that converts dynamically generated pixel data into a compressed JPEG2000 file for web delivery, the example shows the necessary steps to create the image, write ARGB32 pixels, and write the output to disk.
 * 4. When automating the creation of test assets for a graphics library that expects JPEG2000 inputs with known dimensions and pixel values, developers can use this code to produce a predictable red rectangle image for validation.
 * 5. When a developer wants to embed raw pixel manipulation logic—such as applying a custom filter or algorithm—and then export the result as a JPEG2000 file with Aspose.Imaging for .NET, this example provides the end‑to‑end workflow from pixel array to saved .jp2 file.
 */