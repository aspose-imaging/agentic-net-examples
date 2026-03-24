using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png; // For PNG saving options
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\corrupted.jpg";
        string outputPath = @"C:\Images\output\recovered.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Example 1: No data recovery (default behavior)
        LoadAndSaveImage(inputPath, outputPath, DataRecoveryMode.None, "none");

        // Example 2: Consistent recovery – recovers data as long as the file format remains intact
        LoadAndSaveImage(inputPath, outputPath, DataRecoveryMode.ConsistentRecover, "consistent");

        // Example 3: Maximal recovery – attempts to recover all data even if the format is severely corrupted
        LoadAndSaveImage(inputPath, outputPath, DataRecoveryMode.MaximalRecover, "maximal");
    }

    /// <summary>
    /// Loads an image using the specified data recovery mode and saves it to the output path.
    /// </summary>
    /// <param name="inputPath">Path to the potentially corrupted image file.</param>
    /// <param name="outputPath">Base output path (file name will be suffixed with the mode).</param>
    /// <param name="mode">DataRecoveryMode to apply during loading.</param>
    /// <param name="modeSuffix">Suffix added to the output file name to distinguish the mode.</param>
    private static void LoadAndSaveImage(string inputPath, string outputPath, DataRecoveryMode mode, string modeSuffix)
    {
        // Configure load options with the desired recovery mode
        var loadOptions = new LoadOptions
        {
            DataRecoveryMode = mode
        };

        try
        {
            // Load the image using the configured options
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Prepare a PNG save options instance (could be any format)
                var saveOptions = new PngOptions
                {
                    // You can customize PNG options here if needed
                };

                // Build a distinct output file name for each mode
                string modeSpecificOutput = Path.Combine(
                    Path.GetDirectoryName(outputPath),
                    $"{Path.GetFileNameWithoutExtension(outputPath)}_{modeSuffix}{Path.GetExtension(outputPath)}");

                // Save the image
                image.Save(modeSpecificOutput, saveOptions);
                Console.WriteLine($"Saved image with {mode} recovery to: {modeSpecificOutput}");
            }
        }
        catch (ImageSaveException ex)
        {
            // Handle any errors that occur during saving
            Console.Error.WriteLine($"Failed to save image with {mode} recovery: {ex.Message}");
        }
        catch (Exception ex)
        {
            // General exception handling for loading failures or other issues
            Console.Error.WriteLine($"Error processing image with {mode} recovery: {ex.Message}");
        }
    }
}