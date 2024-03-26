namespace DaddyRecoveryBuilder.Helpers
{
    using System;

    public static class Enums
    {
        #region Для анимации
        [Flags]
        public enum AnimateWindowFlags : int
        {
            AW_HOR_POSITIVE = 1,
            AW_HOR_NEGATIVE = 2,
            AW_VER_POSITIVE = 4,
            AW_VER_NEGATIVE = 8,
            AW_CENTER = 16,
            AW_HIDE = 65536,
            AW_ACTIVATE = 131072,
            AW_SLIDE = 262144,
            AW_BLEND = 524288
        }
        #endregion

        #region Для замены свойства файла
        /// <summary>
        /// Bitmap compression options.
        /// </summary>
        public enum BitmapCompression
        {
            /// <summary>
            /// An uncompressed format. 
            /// </summary>
            BI_RGB = 0,
            /// <summary>
            /// A run-length encoded (RLE) format for bitmaps with 8 bpp. The compression format is a 2-byte format consisting of a count byte followed by a byte containing a color index. For more information, see Bitmap Compression.
            /// </summary>
            BI_RLE8 = 1,
            /// <summary>
            /// An RLE format for bitmaps with 4 bpp. The compression format is a 2-byte format consisting of a count byte followed by two word-length color indexes. For more information, see Bitmap Compression.
            /// </summary>
            BI_RLE4 = 2,
            /// <summary>
            /// Specifies that the bitmap is not compressed and that the color table consists of three DWORD color masks that specify the red, green, and blue components, respectively, of each pixel. This is valid when used with 16- and 32-bpp bitmaps.
            /// </summary>
            BI_BITFIELDS = 3,
            /// <summary>
            /// Windows 98/Me, Windows 2000/XP: Indicates that the image is a JPEG image.
            /// </summary>
            BI_JPEG = 4,
            /// <summary>
            /// Windows 98/Me, Windows 2000/XP: Indicates that the image is a PNG image.
            /// </summary>
            BI_PNG = 5,
        }

        /// <summary>
        /// Defines how to interpret the values in the color table of a DIB.
        /// </summary>
        internal enum DIBColors
        {
            /// <summary>
            /// The color table contains literal RGB values.
            /// </summary>
            DIB_RGB_COLORS = 0,
            /// <summary>
            /// The color table consists of an array of 16-bit indexes into the LogPalette 
            /// object that is currently defined in the playback device context.
            /// </summary>
            DIB_PAL_COLORS = 1,
            /// <summary>
            /// No color table exists. The pixels in the DIB are indices into the current logical 
            /// palette in the playback device context.
            /// </summary>
            DIB_PAL_INDICES = 2,
            /// <summary>
            /// 
            /// </summary>
            DIB_PAL_LOGINDICES = 4
        }

        /// <summary>
        /// VS_VERSION file flags.
        /// </summary>
        public enum FileFlags : uint
        {
            /// <summary>
            /// The file contains debugging information.
            /// </summary>
            VS_FF_DEBUG = 0x00000001,
            /// <summary>
            /// The file is a prerelease development version, not a final commercial release.
            /// </summary>
            VS_FF_PRERELEASE = 0x00000002,
            /// <summary>
            /// PThe file has been modified somehow and is not identical to the original file
            /// that shipped with the product. 
            /// </summary>
            VS_FF_PATCHED = 0x00000004,
            /// <summary>
            /// The file was not built using standard release procedures. There should be data 
            /// in the file's "PrivateBuild" version information string. 
            /// </summary>
            VS_FF_PRIVATEBUILD = 0x00000008,
            /// <summary>
            /// The version information in this structure was not found inside the file, 
            /// but instead was created when needed based on the best information available. 
            /// Therefore, this structure's information may differ slightly from what the "real"
            /// values are.
            /// </summary>
            VS_FF_INFOINFERRED = 0x00000010,
            /// <summary>
            /// The file was built using standard release procedures, but is somehow different 
            /// from the normal file having the same version number. There should be data in the 
            /// file's "SpecialBuild" version information string.
            /// </summary>
            VS_FF_SPECIALBUILD = 0x00000020,
        }

        /// <summary>
        /// VS_VERSION file OSs.
        /// </summary>
        public enum FileOs : uint
        {
            /// <summary>
            /// The operating system under which the file was designed to run could not be determined.
            /// </summary>
            VOS_UNKNOWN = 0x00000000,
            /// <summary>
            /// The file was designed to run under MS-DOS. 
            /// </summary>
            VOS_DOS = 0x00010000,
            /// <summary>
            /// The file was designed to run under a 16-bit version of OS/2. 
            /// </summary>
            VOS_OS216 = 0x00020000,
            /// <summary>
            /// The file was designed to run under a 32-bit version of OS/2.
            /// </summary>
            VOS_OS232 = 0x00030000,
            /// <summary>
            /// The file was designed to run under Windows NT/2000.
            /// </summary>
            VOS_NT = 0x00040000,
            /// <summary>
            /// 
            /// </summary>
            VOS_WINCE = 0x00050000,
            /// <summary>
            /// The file was designed to run under the 16-bit Windows API. 
            /// </summary>
            VOS__WINDOWS16 = 0x00000001,
            /// <summary>
            /// The file was designed to be run under a 16-bit version of Presentation Manager. 
            /// </summary>
            VOS__PM16 = 0x00000002,
            /// <summary>
            /// The file was designed to be run under a 32-bit version of Presentation Manager.
            /// </summary>
            VOS__PM32 = 0x00000003,
            /// <summary>
            /// The file was designed to run under the 32-bit Windows API. 
            /// </summary>
            VOS__WINDOWS32 = 0x00000004,
            /// <summary>
            /// 
            /// </summary>
            VOS_DOS_WINDOWS16 = 0x00010001,
            /// <summary>
            /// 
            /// </summary>
            VOS_DOS_WINDOWS32 = 0x00010004,
            /// <summary>
            /// 
            /// </summary>
            VOS_OS216_PM16 = 0x00020002,
            /// <summary>
            /// 
            /// </summary>
            VOS_OS232_PM32 = 0x00030003,
            /// <summary>
            /// 
            /// </summary>
            VOS_NT_WINDOWS32 = 0x00040004
        }

        /// <summary>
        /// VS_VERSION file types.
        /// </summary>
        public enum FileType : uint
        {
            /// <summary>
            /// The type of file could not be determined.
            /// </summary>
            VFT_UNKNOWN = 0x00000000,
            /// <summary>
            /// The file is an application.
            /// </summary>
            VFT_APP = 0x00000001,
            /// <summary>
            /// The file is a Dynamic Link Library (DLL). 
            /// </summary>
            VFT_DLL = 0x00000002,
            /// <summary>
            /// The file is a device driver. dwFileSubtype contains more information. 
            /// </summary>
            VFT_DRV = 0x00000003,
            /// <summary>
            /// The file is a font. dwFileSubtype contains more information. 
            /// </summary>
            VFT_FONT = 0x00000004,
            /// <summary>
            /// The file is a virtual device.
            /// </summary>
            VFT_VXD = 0x00000005,
            /// <summary>
            /// The file is a static link library.
            /// </summary>
            VFT_STATIC_LIB = 0x00000007
        }

        /// <summary>
        /// File sub-type.
        /// </summary>
        public enum FileSubType : uint
        {
            /// <summary>
            /// The type of driver could not be determined. 
            /// </summary>
            VFT2_UNKNOWN = 0x00000000,
            /// <summary>
            /// The file is a printer driver.
            /// </summary>
            VFT2_DRV_PRINTER = 0x00000001,
            /// <summary>
            /// The file is a keyboard driver. 
            /// </summary>
            VFT2_DRV_KEYBOARD = 0x00000002,
            /// <summary>
            /// The file is a language driver. 
            /// </summary>
            VFT2_DRV_LANGUAGE = 0x00000003,
            /// <summary>
            /// The file is a display driver. 
            /// </summary>
            VFT2_DRV_DISPLAY = 0x00000004,
            /// <summary>
            /// The file is a mouse driver. 
            /// </summary>
            VFT2_DRV_MOUSE = 0x00000005,
            /// <summary>
            /// The file is a network driver. 
            /// </summary>
            VFT2_DRV_NETWORK = 0x00000006,
            /// <summary>
            /// The file is a system driver. 
            /// </summary>
            VFT2_DRV_SYSTEM = 0x00000007,
            /// <summary>
            /// The file is an installable driver. 
            /// </summary>
            VFT2_DRV_INSTALLABLE = 0x00000008,
            /// <summary>
            /// The file is a sound driver. 
            /// </summary>
            VFT2_DRV_SOUND = 0x00000009,
            /// <summary>
            /// The file is a communications driver. 
            /// </summary>
            VFT2_DRV_COMM = 0x0000000A,
            /// <summary>
            /// The file is an input method driver.
            /// </summary>
            VFT2_DRV_INPUTMETHOD = 0x0000000B,
            /// <summary>
            /// The file is a versioned printer driver.
            /// </summary>
            VFT2_DRV_VERSIONED_PRINTER = 0x0000000C,
            /// <summary>
            /// The file is a raster font.
            /// </summary>
            VFT2_FONT_RASTER = 0x00000001,
            /// <summary>
            /// The file is a vector font. 
            /// </summary>
            VFT2_FONT_VECTOR = 0x00000002,
            /// <summary>
            /// The file is a TrueType font. 
            /// </summary>
            VFT2_FONT_TRUETYPE = 0x00000003,
        }

        /// <summary>
        /// Resource header type.
        /// </summary>
        public enum RESOURCE_HEADER_TYPE
        {
            /// <summary>
            /// Binary data.
            /// </summary>
            BinaryData = 0,
            /// <summary>
            /// String data.
            /// </summary>
            StringData = 1
        }

        /// <summary>
        /// Predefined resource types.
        /// </summary>
        public enum ResourceTypes
        {
            /// <summary>
            /// Hardware-dependent cursor resource.
            /// </summary>
            RT_CURSOR = 1,
            /// <summary>
            /// Bitmap resource.
            /// </summary>
            RT_BITMAP = 2,
            /// <summary>
            /// Hardware-dependent icon resource.
            /// </summary>
            RT_ICON = 3,
            /// <summary>
            /// Menu resource.
            /// </summary>
            RT_MENU = 4,
            /// <summary>
            /// Dialog box.
            /// </summary>
            RT_DIALOG = 5,
            /// <summary>
            /// String-table entry.
            /// </summary>
            RT_STRING = 6,
            /// <summary>
            /// Font directory resource.
            /// </summary>
            RT_FONTDIR = 7,
            /// <summary>
            /// Font resource.
            /// </summary>
            RT_FONT = 8,
            /// <summary>
            /// Accelerator table.
            /// </summary>
            RT_ACCELERATOR = 9,
            /// <summary>
            /// Application-defined resource (raw data).
            /// </summary>
            RT_RCDATA = 10,
            /// <summary>
            /// Message-table entry.
            /// </summary>
            RT_MESSAGETABLE = 11,
            /// <summary>
            /// Hardware-independent cursor resource.
            /// </summary>
            RT_GROUP_CURSOR = 12,
            /// <summary>
            /// Hardware-independent icon resource.
            /// </summary>
            RT_GROUP_ICON = 14,
            /// <summary>
            /// Version resource.
            /// </summary>
            RT_VERSION = 16,
            /// <summary>
            /// Allows a resource editing tool to associate a string with an .rc file.
            /// </summary>
            RT_DLGINCLUDE = 17,
            /// <summary>
            /// Plug and Play resource.
            /// </summary>
            RT_PLUGPLAY = 19,
            /// <summary>
            /// VXD.
            /// </summary>
            RT_VXD = 20,
            /// <summary>
            /// Animated cursor.
            /// </summary>
            RT_ANICURSOR = 21,
            /// <summary>
            /// Animated icon.
            /// </summary>
            RT_ANIICON = 22,
            /// <summary>
            /// HTML.
            /// </summary>
            RT_HTML = 23,
            /// <summary>
            /// Microsoft Windows XP: Side-by-Side Assembly XML Manifest.
            /// </summary>
            RT_MANIFEST = 24,
        }

        /// <summary>
        /// Resource manifest type.
        /// </summary>
        public enum ManifestType
        {
            /// <summary>
            /// CREATEPROCESS_MANIFEST_RESOURCE_ID
            /// </summary>
            CreateProcess = NativeMethods.CREATEPROCESS_MANIFEST_RESOURCE_ID,
            /// <summary>
            /// ISOLATIONAWARE_MANIFEST_RESOURCE_ID
            /// </summary>
            IsolationAware = NativeMethods.ISOLATIONAWARE_MANIFEST_RESOURCE_ID,
            /// <summary>
            /// ISOLATIONAWARE_NOSTATICIMPORT_MANIFEST_RESOURCE_ID
            /// </summary>
            IsolationAwareNonstaticImport = NativeMethods.ISOLATIONAWARE_NOSTATICIMPORT_MANIFEST_RESOURCE_ID
        }
        #endregion
    }
}