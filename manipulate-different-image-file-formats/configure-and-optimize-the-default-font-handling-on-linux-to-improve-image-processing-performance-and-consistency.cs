using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public static class LinuxFontConfiguration
{
    // Call this method at application startup to configure font handling.
    public static void Configure()
    {
        // Path to the directory that contains TrueType fonts on Linux.
        // Adjust this path according to your environment.
        string fontsFolder = "/usr/share/fonts/truetype";

        // Ensure the folder exists to avoid runtime errors.
        if (!Directory.Exists(fontsFolder))
        {
            throw new DirectoryNotFoundException($"Fonts folder not found: {fontsFolder}");
        }

        // Set the folder where Aspose.Imaging will look for fonts.
        // The second parameter (bool) indicates whether to clear the cached fonts (true = clear).
        FontSettings.SetFontsFolders(new[] { fontsFolder }, true);

        // Optionally set a default font name that will be used when a requested font is missing.
        // Choose a font that is guaranteed to exist in the specified folder.
        FontSettings.DefaultFontName = "DejaVu Sans";

        // Disable automatic fallback to system alternative fonts for deterministic rendering.
        FontSettings.GetSystemAlternativeFont = false;

        // Update the internal fonts cache, especially important for PSD files with text layers.
        FontSettings.UpdateFonts();
    }

    // Example usage: load an image, apply rasterization options, and save it.
    public static void ProcessImage(string inputPath, string outputPath)
    {
        // Ensure the output directory exists.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image using Aspose.Imaging.
        using (Image image = Image.Load(inputPath))
        {
            // Obtain default rasterization options for vector formats.
            // This example assumes the image is a vector format; adjust as needed.
            var rasterizationOptions = (VectorRasterizationOptions)image.GetDefaultOptions(
                new object[] { Color.White, image.Width, image.Height });

            // Optimize text rendering for performance on Linux.
            rasterizationOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
            rasterizationOptions.SmoothingMode = SmoothingMode.None;

            // Save the processed image.
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };
            image.Save(outputPath, pngOptions);
        }
    }
}

// Example entry point.
class Program
{
    static void Main()
    {
        // Configure font handling once.
        LinuxFontConfiguration.Configure();

        // Process a sample image.
        string inputFile = "/path/to/input/vector_image.cdr";
        string outputFile = "/path/to/output/vector_image.png";
        LinuxFontConfiguration.ProcessImage(inputFile, outputFile);
    }
}