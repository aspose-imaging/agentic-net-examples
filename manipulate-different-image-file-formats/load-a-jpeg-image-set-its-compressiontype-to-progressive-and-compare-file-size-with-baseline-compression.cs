using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.jpg";
            string progressiveOutputPath = @"C:\temp\output_progressive.jpg";
            string baselineOutputPath = @"C:\temp\output_baseline.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(progressiveOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(baselineOutputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // ---------- Save with Progressive compression ----------
                JpegOptions progressiveOptions = new JpegOptions();
                progressiveOptions.CompressionType = JpegCompressionMode.Progressive;
                // Optional: set quality (e.g., 100) to keep other factors constant
                progressiveOptions.Quality = 100;

                image.Save(progressiveOutputPath, progressiveOptions);

                // ---------- Save with Baseline (default) compression ----------
                JpegOptions baselineOptions = new JpegOptions();
                baselineOptions.CompressionType = JpegCompressionMode.Baseline;
                baselineOptions.Quality = 100;

                image.Save(baselineOutputPath, baselineOptions);
            }

            // Compare file sizes
            long progressiveSize = new FileInfo(progressiveOutputPath).Length;
            long baselineSize = new FileInfo(baselineOutputPath).Length;

            Console.WriteLine($"Progressive JPEG size: {progressiveSize} bytes");
            Console.WriteLine($"Baseline JPEG size:   {baselineSize} bytes");

            if (progressiveSize < baselineSize)
                Console.WriteLine("Progressive compression produced a smaller file.");
            else if (progressiveSize > baselineSize)
                Console.WriteLine("Baseline compression produced a smaller file.");
            else
                Console.WriteLine("Both files have the same size.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}