using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\sample.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the JPEG image using Aspose.Imaging
        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            // Access the generic EXIF data container
            JpegExifData exifData = jpegImage.ExifData as JpegExifData;

            if (exifData == null)
            {
                Console.WriteLine("No EXIF data found in the image.");
                return;
            }

            // General EXIF information
            Console.WriteLine("General EXIF data:");
            Console.WriteLine($"  EXIF version: {exifData.ExifVersion}");
            Console.WriteLine($"  Camera serial number: {exifData.BodySerialNumber}");
            Console.WriteLine($"  Color space: {exifData.ColorSpace}");
            Console.WriteLine($"  Brightness: {exifData.BrightnessValue}");
            Console.WriteLine($"  Contrast: {exifData.Contrast}");
            Console.WriteLine($"  Gamma: {exifData.Gamma}");
            Console.WriteLine($"  Sharpness: {exifData.Sharpness}");
            Console.WriteLine($"  Aperture: {exifData.ApertureValue}");
            Console.WriteLine($"  Exposure mode: {exifData.ExposureMode}");
            Console.WriteLine($"  Exposure bias: {exifData.ExposureBiasValue}");
            Console.WriteLine($"  Exposure time: {exifData.ExposureTime}");
            Console.WriteLine($"  Focal length: {exifData.FocalLength}");
            Console.WriteLine($"  Lens model: {exifData.LensModel}");
            Console.WriteLine($"  Shutter speed: {exifData.ShutterSpeedValue}");

            // JPEG‑specific EXIF information
            Console.WriteLine("JPEG EXIF data:");
            Console.WriteLine($"  Manufacturer: {exifData.Make}");
            Console.WriteLine($"  Model: {exifData.Model}");
            Console.WriteLine($"  Photometric interpretation: {exifData.PhotometricInterpretation}");
            Console.WriteLine($"  Artist: {exifData.Artist}");
            Console.WriteLine($"  Copyright: {exifData.Copyright}");
            Console.WriteLine($"  Image description: {exifData.ImageDescription}");
            Console.WriteLine($"  Orientation: {exifData.Orientation}");
            Console.WriteLine($"  Software: {exifData.Software}");
        }
    }
}