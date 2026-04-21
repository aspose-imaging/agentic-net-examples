using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Calculate average brightness before filtering
                int[] beforePixels = raster.LoadArgb32Pixels(raster.Bounds);
                double brightnessBefore = 0;
                foreach (int argb in beforePixels)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    brightnessBefore += (r + g + b) / 3.0;
                }
                brightnessBefore /= beforePixels.Length;

                // Apply motion Wiener filter (size 9, smooth 1.0, angle 180)
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(9, 1.0, 180.0));

                // Calculate average brightness after filtering
                int[] afterPixels = raster.LoadArgb32Pixels(raster.Bounds);
                double brightnessAfter = 0;
                foreach (int argb in afterPixels)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    brightnessAfter += (r + g + b) / 3.0;
                }
                brightnessAfter /= afterPixels.Length;

                // Verify brightness unchanged (tolerance 0.01)
                if (Math.Abs(brightnessAfter - brightnessBefore) < 0.01)
                {
                    Console.WriteLine("Brightness unchanged after applying motion blur.");
                }
                else
                {
                    Console.WriteLine("Brightness changed after applying motion blur.");
                }

                // Save the processed image
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}