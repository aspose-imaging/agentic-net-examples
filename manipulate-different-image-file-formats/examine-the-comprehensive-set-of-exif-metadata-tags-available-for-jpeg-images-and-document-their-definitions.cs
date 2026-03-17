using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the JPEG file (provide via command line or use a default placeholder)
            string jpegPath = args.Length > 0 ? args[0] : "sample.jpg";

            // Load the JPEG image and access its EXIF data (if any)
            using (JpegImage jpeg = (JpegImage)Image.Load(jpegPath))
            {
                // EXIF data container (may be null if the image has no EXIF information)
                JpegExifData exifData = jpeg.ExifData as JpegExifData;
                // The example does not modify EXIF; it only demonstrates loading.
            }

            // Enumerate all EXIF tags defined in the ExifProperties enumeration
            foreach (ExifProperties tag in Enum.GetValues(typeof(ExifProperties)))
            {
                string description = GetTagDescription(tag);
                Console.WriteLine($"{(ushort)tag} - {tag}: {description}");
            }
        }

        // Returns a human‑readable description for each EXIF tag.
        static string GetTagDescription(ExifProperties tag)
        {
            switch (tag)
            {
                case ExifProperties.ImageWidth:
                    // 256
                    return "The number of columns of image data, equal to the number of pixels per row.";
                case ExifProperties.ImageLength:
                    // 257
                    return "The number of rows of image data.";
                case ExifProperties.BitsPerSample:
                    // 258
                    return "The number of bits per image component. In this standard each component of the image is 8 bits, so the value for this tag is 8.";
                case ExifProperties.Compression:
                    // 259
                    return "The compression scheme used for the image data. When a primary image is JPEG compressed, this designation is not necessary and is omitted.";
                case ExifProperties.PhotometricInterpretation:
                    // 262
                    return "The pixel composition.";
                case ExifProperties.ImageDescription:
                    // 270
                    return "A character string giving the title of the image. It may be a comment such as \"1988 company picnic\" or the like.";
                case ExifProperties.Make:
                    // 271
                    return "The manufacturer of the recording equipment. This is the manufacturer of the DSC, scanner, video digitizer or other equipment that generated the image.";
                case ExifProperties.Model:
                    // 272
                    return "The model name or model number of the equipment.";
                case ExifProperties.Orientation:
                    // 274
                    return "The image orientation viewed in terms of rows and columns.";
                case ExifProperties.SamplesPerPixel:
                    // 277
                    return "The number of components per pixel. Since this standard applies to RGB and YCbCr images, the value set for this tag is 3.";
                case ExifProperties.XResolution:
                    // 282
                    return "The number of pixels per ResolutionUnit in the ImageWidth direction. When the image resolution is unknown, 72 [dpi] is designated.";
                case ExifProperties.YResolution:
                    // 283
                    return "The number of pixels per ResolutionUnit in the ImageLength direction. The same value as XResolution is designated.";
                case ExifProperties.PlanarConfiguration:
                    // 284
                    return "Indicates whether pixel components are recorded in a chunky or planar format. If this field does not exist, the TIFF default of 1 (chunky) is assumed.";
                case ExifProperties.ResolutionUnit:
                    // 296
                    return "The unit for measuring XResolution and YResolution. The same unit is used for both XResolution and YResolution. If the image resolution is unknown, 2 (inches) is designated.";
                case ExifProperties.TransferFunction:
                    // 301
                    return "A transfer function for the image, described in tabular style. Normally this tag is not necessary, since color space is specified in the color space information ColorSpace tag.";
                case ExifProperties.Software:
                    // 305
                    return "This tag records the name and version of the software or firmware of the camera or image input device used to generate the image.";
                case ExifProperties.DateTime:
                    // 306
                    return "The date and time of image creation. In Exif standard, it is the date and time the file was changed.";
                case ExifProperties.Artist:
                    // 315
                    return "This tag records the name of the camera owner, photographer or image creator.";
                case ExifProperties.WhitePoint:
                    // 318
                    return "The chromaticity of the white point of the image.";
                case ExifProperties.PrimaryChromaticities:
                    // 319
                    return "The chromaticity of the three primary colors of the image.";
                case ExifProperties.YCbCrCoefficients:
                    // 529
                    return "The matrix coefficients for transformation from RGB to YCbCr image data.";
                case ExifProperties.YCbCrSubSampling:
                    // 530
                    return "The sampling ratio of chrominance components in relation to the luminance component.";
                case ExifProperties.YCbCrPositioning:
                    // 531
                    return "The position of chrominance components in relation to the luminance component.";
                case ExifProperties.ReferenceBlackWhite:
                    // 532
                    return "The reference black point value and reference white point value.";
                case ExifProperties.Copyright:
                    // 33432
                    return "Copyright information. In this standard the tag is used to indicate both the photographer and editor copyrights.";
                case ExifProperties.ExposureTime:
                    // 33434
                    return "Exposure time, given in seconds.";
                case ExifProperties.FNumber:
                    // 33437
                    return "The F number.";
                case ExifProperties.ExposureProgram:
                    // 34850
                    return "The class of the program used by the camera to set exposure when the picture is taken.";
                case ExifProperties.SpectralSensitivity:
                    // 34852
                    return "Indicates the spectral sensitivity of each channel of the camera used.";
                case ExifProperties.PhotographicSensitivity:
                    // 34855
                    return "Indicates the ISO Speed and ISO Latitude of the camera or input device as specified in ISO 12232.";
                case ExifProperties.OECF:
                    // 34856
                    return "Indicates the Opto‑Electric Conversion Function (OECF) specified in ISO 14524.";
                case ExifProperties.ExifVersion:
                    // 36864
                    return "The Exif version.";
                case ExifProperties.DateTimeOriginal:
                    // 36867
                    return "The date and time when the original image data was generated.";
                case ExifProperties.DateTimeDigitized:
                    // 36868
                    return "The date time digitized.";
                case ExifProperties.ComponentsConfiguration:
                    // 37121
                    return "The components' configuration.";
                case ExifProperties.CompressedBitsPerPixel:
                    // 37122
                    return "Specific to compressed data; states the compressed bits per pixel.";
                case ExifProperties.ShutterSpeedValue:
                    // 37377
                    return "The shutter speed value.";
                case ExifProperties.ApertureValue:
                    // 37378
                    return "The lens aperture value.";
                case ExifProperties.BrightnessValue:
                    // 37379
                    return "The brightness value.";
                case ExifProperties.ExposureBiasValue:
                    // 37380
                    return "The exposure bias value.";
                case ExifProperties.MaxApertureValue:
                    // 37381
                    return "The max aperture value.";
                case ExifProperties.SubjectDistance:
                    // 37382
                    return "The distance to the subject, given in meters.";
                case ExifProperties.MeteringMode:
                    // 37383
                    return "The metering mode.";
                case ExifProperties.LightSource:
                    // 37384
                    return "The kind light source.";
                case ExifProperties.Flash:
                    // 37385
                    return "Indicates the status of flash when the image was shot.";
                case ExifProperties.FocalLength:
                    // 37386
                    return "The actual focal length of the lens, in mm.";
                case ExifProperties.SubjectArea:
                    // 37396
                    return "This tag indicates the location and area of the main subject in the overall scene.";
                case ExifProperties.MakerNote:
                    // 37500
                    return "A tag for manufacturers of Exif writers to record any desired information.";
                case ExifProperties.UserComment:
                    // 37510
                    return "A tag for Exif users to write keywords or comments on the image besides those in ImageDescription.";
                case ExifProperties.SubsecTime:
                    // 37520
                    return "A tag used to record fractions of seconds for the DateTime tag.";
                case ExifProperties.SubsecTimeOriginal:
                    // 37521
                    return "A tag used to record fractions of seconds for the DateTimeOriginal tag.";
                case ExifProperties.SubsecTimeDigitized:
                    // 37522
                    return "A tag used to record fractions of seconds for the DateTimeDigitized tag.";
                case ExifProperties.FlashpixVersion:
                    // 40960
                    return "The Flashpix format version supported by a FPXR file.";
                case ExifProperties.ColorSpace:
                    // 40961
                    return "The color space information tag (ColorSpace) is always recorded as the color space specifier.";
                case ExifProperties.RelatedSoundFile:
                    // 40964
                    return "The related sound file.";
                case ExifProperties.FlashEnergy:
                    // 41483
                    return "Indicates the strobe energy at the time the image is captured, as measured in Beam Candle Power Seconds (BCPS).";
                case ExifProperties.SpatialFrequencyResponse:
                    // 41484
                    return "This tag records the camera or input device spatial frequency table and SFR values.";
                case ExifProperties.FocalPlaneXResolution:
                    // 41486
                    return "Indicates the number of pixels in the image width (X) direction per FocalPlaneResolutionUnit on the camera focal plane.";
                case ExifProperties.FocalPlaneYResolution:
                    // 41487
                    return "Indicates the number of pixels in the image height (Y) direction per FocalPlaneResolutionUnit on the camera focal plane.";
                case ExifProperties.FocalPlaneResolutionUnit:
                    // 41488
                    return "Indicates the unit for measuring FocalPlaneXResolution and FocalPlaneYResolution. This value is the same as the ResolutionUnit.";
                case ExifProperties.SubjectLocation:
                    // 41492
                    return "Indicates the location of the main subject in the scene.";
                case ExifProperties.ExposureIndex:
                    // 41493
                    return "Indicates the exposure index selected on the camera or input device at the time the image is captured.";
                case ExifProperties.SensingMethod:
                    // 41495
                    return "Indicates the image sensor type on the camera or input device.";
                case ExifProperties.FileSource:
                    // 41728
                    return "The file source.";
                case ExifProperties.SceneType:
                    // 41729
                    return "Indicates the type of scene. If a DSC recorded the image, this tag value shall always be set to 1.";
                case ExifProperties.CFAPattern:
                    // 41730
                    return "Indicates the color filter array (CFA) geometric pattern of the image sensor when a one‑chip color area sensor is used.";
                case ExifProperties.CustomRendered:
                    // 41985
                    return "This tag indicates the use of special processing on image data, such as rendering geared to output.";
                case ExifProperties.ExposureMode:
                    // 41986
                    return "This tag indicates the exposure mode set when the image was shot.";
                case ExifProperties.WhiteBalance:
                    // 41987
                    return "This tag indicates the white balance mode set when the image was shot.";
                case ExifProperties.DigitalZoomRatio:
                    // 41988
                    return "This tag indicates the digital zoom ratio when the image was shot.";
                case ExifProperties.FocalLengthIn35MmFilm:
                    // 41989
                    return "This tag indicates the equivalent focal length assuming a 35mm film camera, in mm.";
                case ExifProperties.SceneCaptureType:
                    // 41990
                    return "This tag indicates the type of scene that was shot.";
                case ExifProperties.GainControl:
                    // 41991
                    return "This tag indicates the degree of overall image gain adjustment.";
                case ExifProperties.Contrast:
                    // 41992
                    return "This tag indicates the direction of contrast processing applied by the camera when the image was shot.";
                case ExifProperties.Saturation:
                    // 41993
                    return "This tag indicates the direction of saturation processing applied by the camera when the image was shot.";
                case ExifProperties.Sharpness:
                    // 41994
                    return "This tag indicates the direction of sharpness processing applied by the camera when the image was shot.";
                case ExifProperties.DeviceSettingDescription:
                    // 41995
                    return "This tag indicates information on the picture‑taking conditions of a particular camera model.";
                case ExifProperties.SubjectDistanceRange:
                    // 41996
                    return "This tag indicates the distance to the subject.";
                case ExifProperties.ImageUniqueID:
                    // 42016
                    return "The image unique id.";
                case ExifProperties.GPSVersionID:
                    // 0
                    return "Indicates the version of GPSInfoIFD.";
                case ExifProperties.GPSLatitudeRef:
                    // 1
                    return "Indicates whether the latitude is north or south latitude.";
                case ExifProperties.GPSLatitude:
                    // 2
                    return "Indicates the latitude. Expressed as three RATIONAL values (degrees, minutes, seconds).";
                case ExifProperties.GPSLongitudeRef:
                    // 3
                    return "Indicates whether the longitude is east or west longitude.";
                case ExifProperties.GPSLongitude:
                    // 4
                    return "Indicates the longitude. Expressed as three RATIONAL values (degrees, minutes, seconds).";
                case ExifProperties.GPSAltitudeRef:
                    // 5
                    return "Indicates the altitude used as the reference altitude.";
                case ExifProperties.GPSAltitude:
                    // 6
                    return "Indicates the altitude based on the reference in GPSAltitudeRef. Altitude is expressed as one RATIONAL value (meters).";
                case ExifProperties.GPSTimestamp:
                    // 7
                    return "Indicates the time as UTC. Expressed as three RATIONAL values (hour, minute, second).";
                case ExifProperties.GPSSatellites:
                    // 8
                    return "Indicates the GPS satellites used for measurements.";
                case ExifProperties.GPSStatus:
                    // 9
                    return "Indicates the status of the GPS receiver when the image is recorded.";
                case ExifProperties.GPSMeasureMode:
                    // 10
                    return "Indicates the GPS measurement mode (2‑ or 3‑dimensional).";
                case ExifProperties.GPSDOP:
                    // 11
                    return "Indicates the GPS DOP (data degree of precision).";
                case ExifProperties.GPSSpeedRef:
                    // 12
                    return "Indicates the unit used to express the GPS receiver speed of movement.";
                case ExifProperties.GPSSpeed:
                    // 13
                    return "Indicates the speed of GPS receiver movement.";
                case ExifProperties.GPSTrackRef:
                    // 14
                    return "Indicates the reference for giving the direction of GPS receiver movement.";
                case ExifProperties.GPSTrack:
                    // 15
                    return "Indicates the direction of GPS receiver movement (0.00‑359.99).";
                case ExifProperties.GPSImgDirectionRef:
                    // 16
                    return "Indicates the reference for giving the direction of the image when it is captured.";
                case ExifProperties.GPSImgDirection:
                    // 17
                    return "Indicates the direction of the image when it was captured.";
                case ExifProperties.GPSMapDatum:
                    // 18
                    return "Indicates the geodetic survey data used by the GPS receiver.";
                case ExifProperties.GPSDestLatitudeRef:
                    // 19
                    return "Indicates whether the latitude of the destination point is north or south latitude.";
                case ExifProperties.GPSDestLatitude:
                    // 20
                    return "Indicates the latitude of the destination point.";
                case ExifProperties.GPSDestLongitudeRef:
                    // 21
                    return "Indicates whether the longitude of the destination point is east or west longitude.";
                case ExifProperties.GPSDestLongitude:
                    // 22
                    return "Indicates the longitude of the destination point.";
                case ExifProperties.GPSDestBearingRef:
                    // 23
                    return "Indicates the reference used for giving the bearing to the destination point.";
                case ExifProperties.GPSDestBearing:
                    // 24
                    return "Indicates the bearing to the destination point (0.00‑359.99).";
                case ExifProperties.GPSDestDistanceRef:
                    // 25
                    return "Indicates the unit used to express the distance to the destination point.";
                case ExifProperties.GPSDestDistance:
                    // 26
                    return "Indicates the distance to the destination point.";
                case ExifProperties.GPSProcessingMethod:
                    // 27
                    return "A character string recording the name of the method used for location finding.";
                case ExifProperties.GPSAreaInformation:
                    // 28
                    return "A character string recording the GPS area.";
                case ExifProperties.GPSDateStamp:
                    // 29
                    return "A character string recording date and time information relative to UTC (format YYYY:MM:DD).";
                case ExifProperties.GPSDifferential:
                    // 30
                    return "Indicates whether differential correction is applied to the GPS receiver.";
                default:
                    return "No description available.";
            }
        }
    }
}