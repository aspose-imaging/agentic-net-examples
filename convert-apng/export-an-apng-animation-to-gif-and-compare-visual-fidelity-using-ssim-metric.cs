using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputApngPath = "input.apng";
        string outputGifPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputApngPath))
        {
            Console.Error.WriteLine($"File not found: {inputApngPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

        // Load APNG and export to GIF
        using (ApngImage apng = (ApngImage)Image.Load(inputApngPath))
        {
            GifOptions gifOptions = new GifOptions();
            apng.Save(outputGifPath, gifOptions);
        }

        // Verify the generated GIF exists
        if (!File.Exists(outputGifPath))
        {
            Console.Error.WriteLine($"Failed to create GIF: {outputGifPath}");
            return;
        }

        // Load first frame of APNG
        RasterImage apngFirstFrame;
        using (ApngImage apng = (ApngImage)Image.Load(inputApngPath))
        {
            // The first page is an ApngFrame which can be cast to RasterImage
            apngFirstFrame = (RasterImage)apng.Pages[0];
            apngFirstFrame.CacheData();
        }

        // Load first frame of GIF
        RasterImage gifFirstFrame;
        using (GifImage gif = (GifImage)Image.Load(outputGifPath))
        {
            // The first page is a GifFrameBlock which can be cast to RasterImage
            gifFirstFrame = (RasterImage)gif.Pages[0];
            gifFirstFrame.CacheData();
        }

        // Ensure both frames have the same dimensions
        if (apngFirstFrame.Width != gifFirstFrame.Width || apngFirstFrame.Height != gifFirstFrame.Height)
        {
            Console.Error.WriteLine("Frames have different dimensions; cannot compute SSIM.");
            return;
        }

        int width = apngFirstFrame.Width;
        int height = apngFirstFrame.Height;
        var rect = new Rectangle(0, 0, width, height);

        // Load pixel data
        Aspose.Imaging.Color[] apngPixels = apngFirstFrame.LoadPixels(rect);
        Aspose.Imaging.Color[] gifPixels = gifFirstFrame.LoadPixels(rect);

        // Compute SSIM (grayscale approximation)
        const double K1 = 0.01;
        const double K2 = 0.03;
        const double L = 255.0; // pixel value range
        double C1 = (K1 * L) * (K1 * L);
        double C2 = (K2 * L) * (K2 * L);

        double sumX = 0, sumY = 0;
        double sumX2 = 0, sumY2 = 0;
        double sumXY = 0;
        int N = width * height;

        for (int i = 0; i < N; i++)
        {
            // Convert to grayscale using luminance formula
            double x = 0.299 * apngPixels[i].R + 0.587 * apngPixels[i].G + 0.114 * apngPixels[i].B;
            double y = 0.299 * gifPixels[i].R + 0.587 * gifPixels[i].G + 0.114 * gifPixels[i].B;

            sumX += x;
            sumY += y;
            sumX2 += x * x;
            sumY2 += y * y;
            sumXY += x * y;
        }

        double meanX = sumX / N;
        double meanY = sumY / N;
        double varX = sumX2 / N - meanX * meanX;
        double varY = sumY2 / N - meanY * meanY;
        double covXY = sumXY / N - meanX * meanY;

        double ssim = ((2 * meanX * meanY + C1) * (2 * covXY + C2)) /
                      ((meanX * meanX + meanY * meanY + C1) * (varX + varY + C2));

        Console.WriteLine($"SSIM between original APNG and exported GIF: {ssim:F4}");
    }
}