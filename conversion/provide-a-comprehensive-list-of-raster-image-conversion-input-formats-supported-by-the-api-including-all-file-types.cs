using System;
using System.Collections.Generic;
using Aspose.Imaging;

namespace AsposeImagingSupportedFormats
{
    class Program
    {
        static void Main()
        {
            // List of raster image formats that Aspose.Imaging can load (input formats).
            // This list is based on the formats for which Aspose.Imaging provides dedicated image classes
            // and corresponding ImageOptions (e.g., BmpOptions, JpegOptions, PngOptions, etc.).
            // Note: The library may support additional formats via plugins or future updates.
            var rasterInputFormats = new List<string>
            {
                // Bitmap formats
                "BMP",   // Windows Bitmap
                "DIB",   // Device Independent Bitmap (same as BMP)

                // JPEG formats
                "JPG",
                "JPEG",
                "JPE",
                "JPF",
                "JPM",
                "JP2",   // JPEG 2000
                "J2K",
                "J2C",
                "JXR",   // JPEG XR

                // PNG format
                "PNG",

                // TIFF formats
                "TIFF",
                "TIF",

                // GIF format
                "GIF",

                // ICO format
                "ICO",

                // Windows Metafile formats (raster representation)
                "EMF",
                "WMF",

                // Photoshop format
                "PSD",

                // DICOM medical imaging format
                "DICOM",
                "DCM",

                // DjVu document format
                "DJVU",
                "DJV",

                // WebP format
                "WEBP",

                // APNG (Animated PNG) format
                "APNG",

                // HEIF / HEIC formats (High Efficiency Image File)
                "HEIF",
                "HEIC",

                // OpenEXR format (high dynamic range)
                "EXR",

                // HDR (Radiance) format
                "HDR",

                // PCX format
                "PCX",

                // PNM family (PBM, PGM, PPM)
                "PBM",
                "PGM",
                "PPM",
                "PNM",

                // SVG is vector; omitted from raster list
                // Additional formats may be added in newer library versions
            };

            Console.WriteLine("Aspose.Imaging (v2) supported raster image input formats:");
            foreach (var fmt in rasterInputFormats)
            {
                Console.WriteLine($"- {fmt}");
            }
        }
    }
}