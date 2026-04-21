using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        Image image = null;
        try
        {
            // Load the source image
            image = Image.Load(inputPath);

            // Define PNG save options (default settings)
            var pngOptions = new PngOptions();

            // Save the image to the output path
            image.Save(outputPath, pngOptions);
        }
        catch (ImageSaveException ex)
        {
            // Handle errors that occur during saving
            Console.Error.WriteLine($"Error saving image: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle any other processing errors
            Console.Error.WriteLine($"Error processing image: {ex.Message}");
        }
        finally
        {
            // Ensure the image is disposed even if an exception occurs
            if (image != null)
                image.Dispose();
        }
    }
}