using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string sourcePath = "input.png";
            string configPath = "config.json";
            string outputPath = "output.apng";

            // Input file existence checks
            if (!File.Exists(sourcePath))
            {
                Console.Error.WriteLine($"File not found: {sourcePath}");
                return;
            }
            if (!File.Exists(configPath))
            {
                Console.Error.WriteLine($"File not found: {configPath}");
                return;
            }

            // Read and parse JSON configuration (expects an array of integers)
            string json = File.ReadAllText(configPath);
            int[] delays = json
                .Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => int.TryParse(s, out _))
                .Select(s => int.Parse(s))
                .ToArray();

            using (RasterImage sourceImage = (RasterImage)Image.Load(sourcePath))
            {
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create APNG options
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = delays.Length > 0 ? (uint)delays[0] : (uint)100
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
                {
                    apng.RemoveAllFrames();

                    // Add frames with specific delays
                    foreach (int delay in delays)
                    {
                        apng.AddFrame(sourceImage, (uint)delay);
                    }

                    // Save the APNG
                    apng.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}