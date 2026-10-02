// HOW-TO: Make ConvolutionFilter Thread Safe for Parallel Image Processing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class ConvolutionFilter
    {
        private readonly double[,] kernel;
        private readonly int kernelWidth;
        private readonly int kernelHeight;
        private readonly int kCenterX;
        private readonly int kCenterY;

        public ConvolutionFilter(double[,] kernel)
        {
            this.kernel = (double[,])kernel.Clone();
            kernelHeight = kernel.GetLength(0);
            kernelWidth = kernel.GetLength(1);
            kCenterX = kernelWidth / 2;
            kCenterY = kernelHeight / 2;
        }

        public byte[,] Apply(byte[,] source)
        {
            int height = source.GetLength(0);
            int width = source.GetLength(1);
            byte[,] result = new byte[height, width];

            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    double sum = 0.0;
                    for (int m = 0; m < kernelHeight; m++)
                    {
                        int mm = kernelHeight - 1 - m;
                        for (int n = 0; n < kernelWidth; n++)
                        {
                            int nn = kernelWidth - 1 - n;
                            int ii = y + (m - kCenterY);
                            int jj = x + (n - kCenterX);
                            if (ii >= 0 && ii < height && jj >= 0 && jj < width)
                            {
                                sum += source[ii, jj] * kernel[mm, nn];
                            }
                        }
                    }
                    int val = (int)Math.Round(sum);
                    if (val < 0) val = 0;
                    if (val > 255) val = 255;
                    result[y, x] = (byte)val;
                }
            });

            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.raw";
                string outputPath = "output.raw";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Placeholder: load a raw grayscale image of known dimensions
                int width = 256;
                int height = 256;
                byte[,] image = new byte[height, width];
                using (var fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                {
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            int b = fs.ReadByte();
                            if (b == -1) break;
                            image[y, x] = (byte)b;
                        }
                    }
                }

                double[,] kernel = {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };
                var filter = new ConvolutionFilter(kernel);
                byte[,] result = filter.Apply(image);

                using (var fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            fs.WriteByte(result[y, x]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When processing large grayscale bitmap images on a multi‑core server, you can apply a sharpening kernel concurrently without race conditions.
 * 2. When implementing real‑time edge detection in a C# web service, the thread‑safe filter lets multiple requests run the convolution in parallel safely.
 * 3. When building a batch image‑enhancement tool that applies blur or emboss kernels to thousands of files, the parallelized filter speeds up the job while keeping each filter instance safe.
 * 4. When integrating custom convolution kernels into an Aspose.Imaging workflow, the code ensures that parallel loops do not corrupt shared kernel data.
 * 5. When developing a desktop photo editor that supports live preview of filter effects, the thread‑safe implementation allows UI threads to compute the effect on background cores without crashes.
 */
