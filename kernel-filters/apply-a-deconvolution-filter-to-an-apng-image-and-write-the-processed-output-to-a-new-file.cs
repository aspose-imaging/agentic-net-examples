using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using System.Drawing;

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the folder containing the source APNG file.
        string dataDir = @"c:\temp\";

        // Load the APNG image.
        using (Image image = Image.Load(dataDir + "input.apng"))
        {
            // Cast the generic Image to ApngImage to access APNG‑specific members.
            ApngImage apngImage = (ApngImage)image;

            // Define a simple 3×3 sharpening kernel.
            // The kernel is supplied as a one‑dimensional array in row‑major order.
            double[] kernel = new double[]
            {
                0, -1, 0,
               -1, 5, -1,
                0, -1, 0
            };

            // Create deconvolution filter options with the kernel.
            DeconvolutionFilterOptions deconvOptions = new DeconvolutionFilterOptions(kernel)
            {
                // Optional: adjust brightness and signal‑to‑noise ratio if needed.
                Brightness = 1.15,   // default value
                Snr = 0.007           // default value
            };

            // Apply the deconvolution filter to the whole image.
            apngImage.Filter(apngImage.Bounds, deconvOptions);

            // Save the processed image to a new PNG file.
            apngImage.Save(dataDir + "output.png", new PngOptions());
        }
    }
}