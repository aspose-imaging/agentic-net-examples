using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input JPEG file paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
        };

        // Hardcoded output JPEG file path
        string outputPath = @"C:\Images\combined.jpg";

        // Validate each input file exists
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Load all input images
        Image[] images = new Image[inputPaths.Length];
        for (int i = 0; i < inputPaths.Length; i++)
        {
            images[i] = Image.Load(inputPaths[i]);
        }

        // Determine combined image dimensions (horizontal concatenation)
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (var img in images)
        {
            totalWidth += img.Width;
            if (img.Height > maxHeight) maxHeight = img.Height;
        }

        // Prepare JPEG options based on the first image to keep original compression parameters
        JpegOptions jpegOptions = new JpegOptions();
        if (images[0] is JpegImage firstJpeg && firstJpeg.JpegOptions != null)
        {
            jpegOptions.Quality = firstJpeg.JpegOptions.Quality;
            jpegOptions.CompressionType = firstJpeg.JpegOptions.CompressionType;
            jpegOptions.ColorType = firstJpeg.JpegOptions.ColorType;
            jpegOptions.BitsPerChannel = firstJpeg.JpegOptions.BitsPerChannel;
        }
        else
        {
            // Fallback defaults if the first image is not a JPEG
            jpegOptions.Quality = 100;
            jpegOptions.CompressionType = JpegCompressionMode.Baseline;
            jpegOptions.BitsPerChannel = 8;
        }

        // Create the combined image using the prepared JPEG options
        using (Image combined = Image.Create(jpegOptions, totalWidth, maxHeight))
        {
            // Draw each source image onto the combined canvas
            var graphics = new Graphics(combined);
            int offsetX = 0;
            foreach (var src in images)
            {
                graphics.DrawImage(src, new Rectangle(offsetX, 0, src.Width, src.Height));
                offsetX += src.Width;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the combined image preserving the JPEG options
            combined.Save(outputPath, jpegOptions);
        }

        // Dispose loaded source images
        foreach (var img in images)
        {
            img.Dispose();
        }
    }
}