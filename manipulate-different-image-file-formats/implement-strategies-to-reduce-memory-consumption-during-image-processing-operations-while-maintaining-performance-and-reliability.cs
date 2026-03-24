using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image as a raster image
        using (RasterImage source = (RasterImage)Image.Load(inputPath))
        {
            // Cache data to avoid repeated I/O during processing
            if (!source.IsCached) source.CacheData();

            // Configure creation options with a memory limit (BufferSizeHint)
            JpegOptions createOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false), // binds the output file
                Quality = 90,
                BufferSizeHint = 50, // limit internal buffers to 50 MB
                CompressionType = JpegCompressionMode.Progressive
            };

            // Create a new canvas image bound to the output file
            using (Image canvas = Image.Create(createOptions, source.Width, source.Height))
            {
                // Perform drawing operations (Graphics, Pen) without using blocks
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.LightGray);
                Pen pen = new Pen(Color.Red, 5f);
                graphics.DrawLine(pen, 0, 0, canvas.Width, canvas.Height);

                // Resize using a low‑memory resample type
                canvas.Resize(canvas.Width / 2, canvas.Height / 2, ResizeType.NearestNeighbourResample);

                // Save the bound image (no path needed, file already bound)
                canvas.Save();
            }
        }
    }
}