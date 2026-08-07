using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.gif";
        string outputPath = @"c:\temp\sample_contrast_lossy.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                GifImage gifImage = (GifImage)image;

                // Increase contrast (value range: -100 to 100)
                gifImage.AdjustContrast(50f);

                // Configure lossy GIF compression
                GifOptions saveOptions = new GifOptions
                {
                    MaxDiff = 80 // recommended value for optimal lossy compression
                };

                // Save the high‑contrast GIF with lossy compression
                gifImage.Save(outputPath, saveOptions);
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
 * 1. When a web developer wants to improve the visual clarity of an animated GIF for a marketing banner and reduce its file size for faster page loads, they can use this C# code with Aspose.Imaging to boost contrast and apply lossy GIF compression.
 * 2. When a mobile app needs to display high‑contrast animated icons while keeping the download size low, the code can adjust the GIF contrast and save it with a MaxDiff setting for efficient bandwidth usage.
 * 3. When an e‑learning platform processes user‑uploaded GIF tutorials and wants to enhance readability of the frames without exceeding storage quotas, the developer can run this routine to increase contrast and compress the animation lossily.
 * 4. When a social‑media scheduling tool automatically optimizes GIF memes for better visual impact and quicker sharing, the script provides a C# solution to adjust contrast and apply lossy compression using Aspose.Imaging.
 * 5. When a digital signage system prepares animated GIF advertisements that must be bright and crisp on large screens yet fit within limited memory, this code enables contrast enhancement and size reduction through lossy GIF encoding.
 */