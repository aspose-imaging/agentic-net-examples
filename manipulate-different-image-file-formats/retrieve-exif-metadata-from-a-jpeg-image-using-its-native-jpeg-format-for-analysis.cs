using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Path to the JPEG file
        string jpegPath = @"C:\Temp\sample.jpg";

        // Load the JPEG image using Aspose.Imaging's Image.Load method
        // Cast the loaded image to JpegImage to access JPEG-specific properties
        using (JpegImage jpegImage = (JpegImage)Image.Load(jpegPath))
        {
            // Retrieve the EXIF data container from the image
            JpegExifData exifData = jpegImage.ExifData as JpegExifData;

            if (exifData != null)
            {
                // Output some common EXIF tags
                Console.WriteLine("Camera Manufacturer: {0}", exifData.Make);
                Console.WriteLine("Camera Model: {0}", exifData.Model);
                Console.WriteLine("Image Description: {0}", exifData.ImageDescription);
                Console.WriteLine("Orientation: {0}", exifData.Orientation);
                Console.WriteLine("Software: {0}", exifData.Software);
                Console.WriteLine("Date/Time Original: {0}", exifData.DateTimeOriginal);
                Console.WriteLine("Exposure Time: {0}", exifData.ExposureTime);
                Console.WriteLine("FNumber (Aperture): {0}", exifData.FNumber);
                Console.WriteLine("ISO Speed: {0}", exifData.ISOSpeed);
                Console.WriteLine("Focal Length: {0}", exifData.FocalLength);
                Console.WriteLine("GPS Latitude: {0}", exifData.GPSLatitude);
                Console.WriteLine("GPS Longitude: {0}", exifData.GPSLongitude);
            }
            else
            {
                Console.WriteLine("No EXIF data found in the JPEG image.");
            }
        }
    }
}