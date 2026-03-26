using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    // Hardcoded input and output paths
    private const string InputPath = "input.png";
    private const string OutputPath = "output.svg";

    static void Main()
    {
        // Verify input file exists
        if (!File.Exists(InputPath))
        {
            Console.Error.WriteLine($"File not found: {InputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(OutputPath) ?? ".");

        // Load the image and attempt to save as SVG
        try
        {
            using (Image image = Image.Load(InputPath))
            {
                var svgOptions = new SvgOptions();

                try
                {
                    image.Save(OutputPath, svgOptions);
                }
                catch (SvgImageException ex)
                {
                    LogError(OutputPath, ex.Message);
                }
                catch (ImageSaveException ex)
                {
                    LogError(OutputPath, ex.Message);
                }
                catch (Exception ex)
                {
                    LogError(OutputPath, ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected errors during loading
            LogError(InputPath, ex.Message);
        }
    }

    // Simple error logger
    private static void LogError(string filePath, string message)
    {
        Console.Error.WriteLine($"Error processing '{filePath}': {message}");
    }
}