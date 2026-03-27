using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        Image image = null;
        try
        {
            // Load the source image
            image = Image.Load(inputPath);

            // Prepare PNG save options (default options are sufficient)
            var pngOptions = new PngOptions();

            // Save the image to the output path
            image.Save(outputPath, pngOptions);
        }
        catch (ImageException ex) // Catches both ImageCreateException and ImageSaveException
        {
            // Report any Aspose.Imaging related errors
            Console.Error.WriteLine($"Aspose.Imaging error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Report any other unexpected errors
            Console.Error.WriteLine($"Unexpected error: {ex.Message}");
        }
        finally
        {
            // Ensure the image is disposed even if an exception occurs
            if (image != null)
            {
                image.Dispose();
            }
        }
    }
}