using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input GIF paths
            string[] inputPaths = { "input1.gif", "input2.gif", "input3.gif" };
            // Hardcoded output GIF path
            string outputPath = "output.gif";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            GifImage canvas = null;
            bool first = true;

            foreach (string inputPath in inputPaths)
            {
                // Load GIF image
                GifImage gif = (GifImage)Image.Load(inputPath);
                try
                {
                    // Deskew the GIF (no resize, white background)
                    gif.NormalizeAngle(false, Color.White);

                    if (first)
                    {
                        // Use the first processed GIF as the canvas
                        canvas = gif;
                        first = false;
                    }
                    else
                    {
                        // Append subsequent GIFs as new pages
                        canvas.AddPage(gif);
                        gif.Dispose(); // Dispose after adding
                    }
                }
                catch
                {
                    gif.Dispose();
                    throw;
                }
            }

            if (canvas == null)
            {
                Console.Error.WriteLine("No GIF images were processed.");
                return;
            }

            // Save the merged animated GIF
            GifOptions gifOptions = new GifOptions();
            canvas.Save(outputPath, gifOptions);
            canvas.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}