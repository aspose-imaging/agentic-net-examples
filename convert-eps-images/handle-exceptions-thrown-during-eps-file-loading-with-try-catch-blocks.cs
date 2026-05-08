using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image with load options and handle loading exceptions
            EpsImage epsImage;
            try
            {
                var loadOptions = new EpsLoadOptions(); // default options
                epsImage = (EpsImage)Image.Load(inputPath, loadOptions);
            }
            catch (ImageLoadException ex)
            {
                Console.Error.WriteLine($"Error loading EPS file: {ex.Message}");
                return;
            }

            // Process the image (e.g., resize) and save as PNG
            using (epsImage)
            {
                // Example resize to 500x500 using Mitchell interpolation
                epsImage.Resize(500, 500, ResizeType.Mitchell);

                var pngOptions = new PngOptions();
                epsImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}