using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = @"C:\Temp\input.tif";
            string outputPath = @"C:\Temp\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                SolidBrush brush = new SolidBrush(Color.Red);
                Rectangle rect = new Rectangle(0, 0, 50, 50);
                graphics.FillRectangle(brush, rect);

                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, saveOptions);
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
 * 1. A developer would use this code when they need to load an existing TIFF file, draw a red rectangle on it with Aspose.Imaging graphics, and overwrite the original file on disk using Image.Save with TiffOptions.
 * 2. This snippet is useful when a C# application must programmatically annotate scanned TIFF documents with a colored shape and replace the previous version without creating a new file.
 * 3. When building a batch‑processing tool that reads multi‑page TIFF images, applies simple drawing operations via Graphics and SolidBrush, and saves the modified image back to the same location, this code provides the required overwrite functionality.
 * 4. A developer can employ this example to ensure the output directory exists, modify a TIFF image, and then save the changes while automatically overwriting any existing file at the target path.
 * 5. This approach is ideal for integrating image processing into a workflow that requires loading a TIFF, adding visual markers, and using Aspose.Imaging’s Image.Save to replace the existing file to avoid duplicate copies.
 */