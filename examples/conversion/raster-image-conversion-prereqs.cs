using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

namespace RasterConversionDemo
{
    public static class RasterConversionHelper
    {
        /// <summary>
        /// Checks prerequisites and converts an EPS file to a raster format (e.g., PNG) if possible.
        /// </summary>
        /// <param name="inputPath">Full path to the source EPS file.</param>
        /// <param name="outputPath">Full path where the converted image will be saved.</param>
        public static void ConvertEpsToPng(string inputPath, string outputPath)
        {
            // 1. Verify that the file can be loaded by Aspose.Imaging.
            if (!Image.CanLoad(inputPath))
            {
                throw new InvalidOperationException($"The file '{inputPath}' cannot be loaded as an image.");
            }

            // 2. Load the image using the standard load method (lifecycle rule).
            using (Image image = Image.Load(inputPath))
            {
                // 3. Ensure the loaded image is an EPS image.
                if (image is not EpsImage epsImage)
                {
                    throw new InvalidOperationException("The loaded image is not an EPS image.");
                }

                // 4. Check if the EPS image contains a raster preview.
                if (!epsImage.HasRasterPreview)
                {
                    throw new InvalidOperationException("The EPS image does not contain a raster preview.");
                }

                // 5. Retrieve the raster preview.
                RasterImage rasterPreview = epsImage.RasterPreview;

                // 6. Verify that raw data is available for the raster preview.
                if (rasterPreview == null || !rasterPreview.IsRawDataAvailable)
                {
                    throw new InvalidOperationException("Raster preview is unavailable or raw data cannot be accessed.");
                }

                // 7. Save the raster preview to the desired format using the standard save method (lifecycle rule).
                //    Here we use PNG format as an example.
                var pngOptions = new PngOptions();
                rasterPreview.Save(outputPath, pngOptions);
            }
        }
    }
}