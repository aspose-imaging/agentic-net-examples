using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                GifImage gif = (GifImage)image;

                // Apply Gaussian blur to the entire GIF
                gif.Filter(gif.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Configure lossy compression
                GifOptions options = new GifOptions
                {
                    MaxDiff = 80 // Enable lossy compression with recommended value
                };

                // Save the blurred GIF with lossy compression
                gif.Save(outputPath, options);
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
 * 1. When creating a privacy‑preserving animated preview for a user‑generated GIF, a developer can blur the frames and then apply lossy GIF compression to reduce file size for faster web delivery.
 * 2. When generating low‑bandwidth email newsletters that include animated graphics, a developer can soften the animation with a Gaussian blur and compress it using Aspose.Imaging’s lossy GIF algorithm to stay under size limits.
 * 3. When preparing animated stickers for a mobile app where visual detail is less critical, a developer can apply a blur filter to the GIF and then use the MaxDiff setting to achieve aggressive lossy compression for quicker loading.
 * 4. When building a content‑moderation pipeline that needs to obscure faces in GIF memes before storage, a developer can blur the entire animation and compress it with Aspose.Imaging to save disk space.
 * 5. When optimizing product demo GIFs for e‑commerce sites that require quick page rendering, a developer can soften the animation with a Gaussian blur filter and then apply lossy GIF compression to balance visual quality and performance.
 */