using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output_cropped.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Define the rectangle to crop (left, top, width, height)
                // Adjust these values as needed for the desired region
                int left = 50;
                int top = 50;
                int width = 200;
                int height = 150;
                Rectangle cropArea = new Rectangle(left, top, width, height);

                // Perform the cropping operation
                image.Crop(cropArea);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the cropped image (format inferred from file extension)
                image.Save(outputPath);
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
 * 1. When a developer needs to extract a specific UI element from a large BMP screenshot for automated testing, they can use this C# code to crop the element by pixel coordinates and save it as a separate BMP file.
 * 2. When generating thumbnails of scanned documents stored as BMP files, the code can crop a defined region to create a smaller preview image for a web gallery.
 * 3. When preprocessing satellite imagery in BMP format to isolate a region of interest before applying further analysis, developers can use this snippet to crop the exact pixel rectangle and export it.
 * 4. When creating custom icons from a BMP sprite sheet, the code allows developers to select the icon’s bounding box using left, top, width, and height values and save the cropped icon as an individual BMP file.
 * 5. When sanitizing confidential information by removing surrounding content and keeping only a specific portion of a BMP diagram, the code can crop the required area and store the result for compliance reporting.
 */