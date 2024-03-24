using Microsoft.Win32;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using static System.Windows.Forms.AxHost;

namespace HID_LightingAudio
{
    public partial class Form1 : Form
    {
        IntPtr ft260handle = new IntPtr();
        FT260_STATUS Status = 0;
        bool DLL_Loaded = false;
        byte Front_LED_cycle = 0;
        byte Front_GRPPWM = 0;
        byte Rear_LED_cycle = 0;
        byte Rear_GRPPWM = 0;

        private enum LED_Strip_Type
        {
            LED_STRIP_FRONT = 0x60,
            LED_STRIP_REAR = 0x63
        }

        private enum LED_STRIP_COLOR
        {
            RED,
            GREEN,
            BLUE,
            WHITE,
            YELLOW,
            CYAN,
            MAGENTA,
            OFF
        }

        private enum PCA9643_LED_COLOR
        {
            LDR0 = 0,   // GREEN
            LDR1 = 1,   // RED
            LDR2 = 2,   // Blue
            LDR3 = 3    // Not Used
        }

        private enum PCA9632_LEDOUT
        {
            LDRx_OFF = 0x00,
            LDRx_ON = 0x01,
            LDRx_PWM = 0x02,
            LDRx_GRPPWM = 0x03
        }

        private enum FT260_STATUS
        {
            FT260_OK,
            FT260_INVALID_HANDLE,
            FT260_DEVICE_NOT_FOUND,
            FT260_DEVICE_NOT_OPENED,
            FT260_DEVICE_OPEN_FAIL,
            FT260_DEVICE_CLOSE_FAIL,
            FT260_INCORRECT_INTERFACE,
            FT260_INCORRECT_CHIP_MODE,
            FT260_DEVICE_MANAGER_ERROR,
            FT260_IO_ERROR,
            FT260_INVALID_PARAMETER,
            FT260_NULL_BUFFER_POINTER,
            FT260_BUFFER_SIZE_ERROR,
            FT260_UART_SET_FAIL,
            FT260_RX_NO_DATA,
            FT260_GPIO_WRONG_DIRECTION,
            FT260_INVALID_DEVICE,
            FT260_INVALID_OPEN_DRAIN_SET,
            FT260_INVALID_OPEN_DRAIN_RESET,
            FT260_I2C_READ_FAIL,
            FT260_OTHER_ERROR
        };

        private enum FT260_GPIO2_Pin
        {
            FT260_GPIO2_GPIO = 0,
            FT260_GPIO2_SUSPOUT = 1,
            FT260_GPIO2_PWREN = 2,
            FT260_GPIO2_TX_LED = 4
        };

        private enum FT260_GPIOA_Pin
        {
            FT260_GPIOA_GPIO = 0,
            FT260_GPIOA_TX_ACTIVE = 3,
            FT260_GPIOA_TX_LED = 4
        };

        private enum FT260_GPIOG_Pin
        {
            FT260_GPIOG_GPIO = 0,
            FT260_GPIOG_PWREN = 2,
            FT260_GPIOG_RX_LED = 5,
            FT260_GPIOG_BCD_DET = 6
        };

        private enum FT260_Clock_Rate
        {
            FT260_SYS_CLK_12M = 0,
            FT260_SYS_CLK_24M,
            FT260_SYS_CLK_48M,
        };

        private enum FT260_Interrupt_Trigger_Type
        {
            FT260_INTR_RISING_EDGE = 0,
            FT260_INTR_LEVEL_HIGH,
            FT260_INTR_FALLING_EDGE,
            FT260_INTR_LEVEL_LOW
        };

        private enum FT260_Interrupt_Level_Time_Delay
        {
            FT260_INTR_DELY_1MS = 1,
            FT260_INTR_DELY_5MS,
            FT260_INTR_DELY_30MS
        };

        private enum FT260_Suspend_Out_Polarity
        {
            FT260_SUSPEND_OUT_LEVEL_HIGH = 0,
            FT260_SUSPEND_OUT_LEVEL_LOW
        };

        private enum FT260_UART_Mode
        {
            FT260_UART_OFF = 0,
            FT260_UART_RTS_CTS_MODE,        // hardware flow control RTS, CTS mode
            FT260_UART_DTR_DSR_MODE,        // hardware flow control DTR, DSR mode
            FT260_UART_XON_XOFF_MODE,       // software flow control mode
            FT260_UART_NO_FLOW_CTRL_MODE    // no flow control mode
        };

        private enum FT260_Data_Bit
        {
            FT260_DATA_BIT_7 = 7,
            FT260_DATA_BIT_8 = 8
        };

        private enum FT260_Stop_Bit
        {
            FT260_STOP_BITS_1 = 0,
            FT260_STOP_BITS_2 = 2
        };

        private enum FT260_Parity
        {
            FT260_PARITY_NONE = 0,
            FT260_PARITY_ODD,
            FT260_PARITY_EVEN,
            FT260_PARITY_MARK,
            FT260_PARITY_SPACE
        };

        private enum FT260_RI_Wakeup_Type
        {
            FT260_RI_WAKEUP_RISING_EDGE = 0,
            FT260_RI_WAKEUP_FALLING_EDGE,
        };

        //struct FT260_GPIO_Report
        //{
        //    WORD value;       // GPIO0~5 values
        //    WORD dir;         // GPIO0~5 directions
        //    WORD gpioN_value; // GPIOA~H values
        //    WORD gpioN_dir;   // GPIOA~H directions
        //};

        private enum FT260_GPIO_DIR
        {
            FT260_GPIO_IN = 0,
            FT260_GPIO_OUT
        };

        private enum FT260_GPIO
        {
            FT260_GPIO_0 = 1 << 0,
            FT260_GPIO_1 = 1 << 1,
            FT260_GPIO_2 = 1 << 2,
            FT260_GPIO_3 = 1 << 3,
            FT260_GPIO_4 = 1 << 4,
            FT260_GPIO_5 = 1 << 5,
            FT260_GPIO_A = 1 << 6,
            FT260_GPIO_B = 1 << 7,
            FT260_GPIO_C = 1 << 8,
            FT260_GPIO_D = 1 << 9,
            FT260_GPIO_E = 1 << 10,
            FT260_GPIO_F = 1 << 11,
            FT260_GPIO_G = 1 << 12,
            FT260_GPIO_H = 1 << 13
        };

        private enum FT260_I2C_FLAG
        {
            FT260_I2C_NONE = 0,
            FT260_I2C_START = 0x02,
            FT260_I2C_REPEATED_START = 0x03,
            FT260_I2C_STOP = 0x04,
            FT260_I2C_START_AND_STOP = 0x06
        };

        private enum FT260_PARAM_1
        {
            FT260_DS_CTL0 = 0x50,
            FT260_DS_CTL3 = 0x51,
            FT260_DS_CTL4 = 0x52,
            FT260_SR_CTL0 = 0x53,
            FT260_GPIO_PULL_UP = 0x61,
            FT260_GPIO_OPEN_DRAIN = 0x62,
            FT260_GPIO_PULL_DOWN = 0x63,
            FT260_GPIO_GPIO_SLEW_RATE = 0x65
        };

        private enum FT260_PARAM_2
        {
            FT260_GPIO_GROUP_SUSPEND_0 = 0x10, // for gpio 0 ~ gpio 5
            FT260_GPIO_GROUP_SUSPEND_A = 0x11, // for gpio A ~ gpio H
            FT260_GPIO_DRIVE_STRENGTH = 0x64
        };

        // LIBFT260_API FT260_STATUS WINAPI FT260_CreateDeviceList(LPDWORD lpdwNumDevs);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_CreateDeviceList(ref UInt32 lpdwNumDevs);

        // LIBFT260_API FT260_STATUS WINAPI FT260_OpenByVidPid(WORD vid, WORD pid, DWORD deviceIndex, FT260_HANDLE* pFt260Handle);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_OpenByVidPid(ushort vid, ushort pid, UInt32 deviceIndex, ref IntPtr ft260handle);

        // LIBFT260_API FT260_STATUS WINAPI FT260_I2CMaster_Init(FT260_HANDLE ft260Handle, uint32 kbps);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_I2CMaster_Init(IntPtr ft260Handle, UInt32 kbps);

        // LIBFT260_API FT260_STATUS WINAPI FT260_I2CMaster_Read(FT260_HANDLE ft260Handle, uint8 deviceAddress, FT260_I2C_FLAG flag, LPVOID lpBuffer, DWORD dwBytesToRead, LPDWORD lpdwBytesReturned, timeout);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_I2CMaster_Read(IntPtr ft260Handle, uint deviceAddress, FT260_I2C_FLAG flag, System.IntPtr lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesReturned, UInt32 Timeout);

        // LIBFT260_API FT260_STATUS WINAPI FT260_I2CMaster_Write(FT260_HANDLE ft260Handle, uint8 deviceAddress, FT260_I2C_FLAG flag, LPVOID lpBuffer, DWORD dwBytesToWrite, LPDWORD lpdwBytesWritten);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_I2CMaster_Write(IntPtr ft260Handle, uint deviceAddress, FT260_I2C_FLAG flag, System.IntPtr lpBuffer, UInt32 dwBytesToWrite, ref UInt32 lpdwBytesWritten);

        // LIBFT260_API FT260_STATUS WINAPI FT260_I2CMaster_GetStatus(FT260_HANDLE ft260Handle, uint8* status);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_I2CMaster_GetStatus(IntPtr ft260Handle, ref byte status);

        // LIBFT260_API FT260_STATUS WINAPI FT260_I2CMaster_Reset(FT260_HANDLE ft260Handle);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_I2CMaster_Reset(IntPtr ft260Handle);

        //LIBFT260_API FT260_STATUS WINAPI FT260_GPIO_SetDir(FT260_HANDLE ft260Handle, WORD pinNum, BYTE dir);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_GPIO_SetDir(IntPtr ft260Handle, FT260_GPIO pinNum, byte dir);

        // LIBFT260_API FT260_STATUS WINAPI FT260_GPIO_Read(FT260_HANDLE ft260Handle, WORD pinNum, BYTE* pValue);

        //LIBFT260_API FT260_STATUS WINAPI FT260_GPIO_Write(FT260_HANDLE ft260Handle, WORD pinNum, BYTE value);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_GPIO_Write(IntPtr ft260Handle, FT260_GPIO pinNum, byte value);

        //LIBFT260_API FT260_STATUS WINAPI FT260_Close(FT260_HANDLE ft260Handle);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_Close(IntPtr ft260Handle);

        //LIBFT260_API FT260_STATUS WINAPI FT260_SelectGpio2Function(FT260_HANDLE ft260Handle, FT260_GPIO2_Pin);
        [DllImport("LibFT260.dll")]
        private static extern FT260_STATUS FT260_SelectGpio2Function(IntPtr ft260Handle, byte value);

        public Form1()
        {
            InitializeComponent();

            byte result = 0;
            result = Init_FT260();

        }

        private void SetControls_Error(String ErrorText, FT260_STATUS Status)
        {
            labelStatus.ForeColor = Color.Red;
            labelStatus.Text = ErrorText.ToString() + ": " + Status.ToString();
        }

        private void SetControls_Error_AllowReInit(String ErrorText, FT260_STATUS Status)
        {
            labelStatus.Text = ErrorText.ToString() + ": " + Status.ToString();
            if (DLL_Loaded == true)
            {
                Status = FT260_Close(ft260handle);
            }
        }

        private byte Init_FT260()
        {
            byte result = 0;
            UInt32 NumDev = 0;
            byte I2Cstatus = 0;

            DLL_Loaded = false;

            try
            {
                Status = FT260_CreateDeviceList(ref NumDev);
            }
            catch (DllNotFoundException)
            {
                SetControls_Error("No LibFT260.DLL Found", Status);
                return 1;
            }
            catch //(AccessViolationException)
            {
                SetControls_Error_AllowReInit("Device Stopped", Status);
                return 1;
            }

            if (Status != FT260_STATUS.FT260_OK)
            {
                SetControls_Error("FT260 Error: ", Status);
                return 1;
            }

            DLL_Loaded = true;
            labelStatus.Text = "DLL loaded OK";

            // -------------------------------------------------------------------------------------
            Status = FT260_OpenByVidPid(0x0403, 0x6030, 0, ref ft260handle);

            if (Status != FT260_STATUS.FT260_OK)
            {
                SetControls_Error("Please check hardware and re-start application", Status);
                return 1;
            }

            // -------------------------------------------------------------------------------------

            Status = FT260_I2CMaster_Init(ft260handle, 100);

            if (Status != FT260_STATUS.FT260_OK)
            {
                SetControls_Error("Please check hardware and re-start application", Status);
                return 1;
            }

            // -------------------------------------------------------------------------------------
            /* I2C Master Controller Status (I2Cstatus variable)
            *   bit 0 = controller busy: all other status bits invalid
            *   bit 1 = error condition
            *   bit 2 = slave address was not acknowledged during last operation
            *   bit 3 = data not acknowledged during last operation
            *   bit 4 = arbitration lost during last operation
            *   bit 5 = controller idle
            *   bit 6 = bus busy
            */
            /////  uint8 I2Cstatus;

            Status = FT260_I2CMaster_GetStatus(ft260handle, ref I2Cstatus);

            if (Status != FT260_STATUS.FT260_OK)
            {
                SetControls_Error("Please check hardware and re-start application", Status);
                return 1;
            }


            // -------------------------------------------------------------------------------------

            // configure GPIO2 output function:
            Status = FT260_SelectGpio2Function(ft260handle, 0);
            if (Status != FT260_STATUS.FT260_OK)
            {
                SetControls_Error("Cannot configure GPIO2 Output", Status);
                return 1;
            }

            Status = FT260_GPIO_SetDir(ft260handle, FT260_GPIO.FT260_GPIO_2, 1);    // Amp Enable

            if (Status != FT260_STATUS.FT260_OK)
            {
                SetControls_Error("Please check hardware and re-start application", Status);
                return 1;
            }

            Status = FT260_GPIO_Write(ft260handle, FT260_GPIO.FT260_GPIO_2, 1);    // Amp Enabled

            if (Status != FT260_STATUS.FT260_OK)
            {
                SetControls_Error("Please check hardware and re-start application", Status);
                return 1;
            }

            Status = FT260_GPIO_SetDir(ft260handle, FT260_GPIO.FT260_GPIO_H, 1);    // Audio Mute

            if (Status != FT260_STATUS.FT260_OK)
            {
                SetControls_Error("Please check hardware and re-start application", Status);
                return 1;
            }

            Status = FT260_GPIO_Write(ft260handle, FT260_GPIO.FT260_GPIO_H, 1);    // Not Muted

            if (Status != FT260_STATUS.FT260_OK)
            {
                SetControls_Error("Please check hardware and re-start application", Status);
                return 1;
            }

            checkBox1.Checked = true;
            checkBox2.Checked = false;

            // -- Initialize the Front Strip -- 
            // Configure PCA9632 Mode Register 1 (00h) to Enable oscillator, no auto-increment
            // Set Mode Register 2 (MODE2 = 0x01) 00000000
            if (WritePCA9632Register(LED_Strip_Type.LED_STRIP_FRONT, 0x00, 0x00) == 1)
            {
                return 1;
            }

            // Configure PCA9632 device for External N-Type driver without pullups INVRT(4)=1, OUTDRV(2)=1 or INVRT=0, OUTDRV=1
            // Set Mode Register 2 (MODE2 = 0x01) 0001 0101 = 0x15
            if (WritePCA9632Register(LED_Strip_Type.LED_STRIP_FRONT, 0x01, 0x15) == 1)
            {
                return 1;
            }

            // -- Initialize the Rear Strip -- 
            // Configure PCA9632 Mode Register 1 (00h) to Enable oscillator, no auto-increment
            // Set Mode Register 2 (MODE2 = 0x01) 00000000
            if (WritePCA9632Register(LED_Strip_Type.LED_STRIP_REAR, 0x00, 0x00) == 1)
            {
                return 1;
            }

            // Configure PCA9632 device for External N-Type driver without pullups INVRT(4)=1, OUTDRV(2)=1 or INVRT=0, OUTDRV=1
            // Set Mode Register 2 (MODE2 = 0x01) 0001 0101 = 0x15
            if (WritePCA9632Register(LED_Strip_Type.LED_STRIP_REAR, 0x01, 0x15) == 1)
            {
                return 1;
            }

            // Initialize the PWM registers
            WritePWMxRegister(LED_Strip_Type.LED_STRIP_FRONT, 0xFF);
            WritePWMxRegister(LED_Strip_Type.LED_STRIP_REAR, 0xFF);

            // Read the current GRPPWN (06h) - Group Duty Cycle Control value of Front Strip
            Front_GRPPWM = ReadPCA9632Register(LED_Strip_Type.LED_STRIP_FRONT, 0x06);
            FrontnumericUpDown1.Value = Front_GRPPWM >> 4;  // lower 4-bits are unused in Group PWM mode

            // Read the current GRPPWN (06h) - Group Duty Cycle Control value of Rear Strip
            Rear_GRPPWM = ReadPCA9632Register(LED_Strip_Type.LED_STRIP_REAR, 0x06);
            RearnumericUpDown1.Value = Rear_GRPPWM >> 4;


            //ReadPCA9632Registers(LED_Strip_Type.LED_STRIP_FRONT);

            return result;
        }

        // Write a single register with a value
        private byte WritePCA9632Register(LED_Strip_Type Strip, byte Register, byte Value)
        {
            UInt32 writeLength = 0;
            UInt32 numBytesToWrite = 0;
            byte[] writeBuffer = new byte[25];

            int size = Marshal.SizeOf(writeBuffer[0]) * writeBuffer.Length;
            IntPtr pnt = Marshal.AllocHGlobal(size);

            // First Set Control Register(00h) to tell it no autoincrement and what register to write, then value
            writeBuffer[0] = Register;
            writeBuffer[1] = Value;

            numBytesToWrite = 2;
            Marshal.Copy(writeBuffer, 0, pnt, writeBuffer.Length);
            Status = FT260_I2CMaster_Write(ft260handle, (uint)Strip, FT260_I2C_FLAG.FT260_I2C_START_AND_STOP, pnt, numBytesToWrite, ref writeLength);
            if ((Status != FT260_STATUS.FT260_OK) || (writeLength != numBytesToWrite))
            {
                SetControls_Error("LED I2C Write failed", Status);
                return 1;
            }

            return 0;
        }

        // Write all 4 PWM registers with a new value for dimming
        // In individual brightness there are 256 steps (0-0xFF)
        // In Group Dimming mode, there are 64 steps 00h to 3Fh and on 6 MSBs are used,
        // lower 2 LSBs are ignored.
        // We use the auto-increment brightness regsiters only mode here (1010
        private byte WritePWMxRegister(LED_Strip_Type Strip, byte Value)
        {
            UInt32 writeLength = 0;
            UInt32 numBytesToWrite = 0;
            byte[] writeBuffer = new byte[25];
            byte Register = 0xA2;   // auto-increment indv bright starting at PWM0

            int size = Marshal.SizeOf(writeBuffer[0]) * writeBuffer.Length;
            IntPtr pnt = Marshal.AllocHGlobal(size);

            // First Set Control Register(00h) to tell it no autoincrement and what register to write, then value
            writeBuffer[0] = Register;
            writeBuffer[1] = Value;     // PWM0
            writeBuffer[2] = Value;     // PWM1
            writeBuffer[3] = Value;     // PWM2
            writeBuffer[4] = Value;     // PWM3

            numBytesToWrite = 4;
            Marshal.Copy(writeBuffer, 0, pnt, writeBuffer.Length);
            Status = FT260_I2CMaster_Write(ft260handle, (uint)Strip, FT260_I2C_FLAG.FT260_I2C_START_AND_STOP, pnt, numBytesToWrite, ref writeLength);
            if ((Status != FT260_STATUS.FT260_OK) || (writeLength != numBytesToWrite))
            {
                SetControls_Error("LED I2C Write failed", Status);
                return 1;
            }

            return 0;
        }

        private byte ReadPCA9632Register(LED_Strip_Type Strip, byte Register)
        {
            // Read register specified of the PCA9632 LED Driver chip
            byte[] Reading = new byte[25];
            UInt32 writeLength = 0;
            UInt32 readLength = 0;
            UInt32 numBytesToRead = 0;
            UInt32 numBytesToWrite = 0;
            byte[] registers = new byte[20];

            int size = Marshal.SizeOf(registers[0]) * registers.Length;
            IntPtr pnt = Marshal.AllocHGlobal(size);

            // Set ControlReg to register to read without increment
            registers[0] = Register;
            numBytesToWrite = 1;
            Marshal.Copy(registers, 0, pnt, registers.Length);
            Status = FT260_I2CMaster_Write(ft260handle, (uint)Strip, FT260_I2C_FLAG.FT260_I2C_START_AND_STOP, pnt, numBytesToWrite, ref writeLength);

            if ((Status != FT260_STATUS.FT260_OK) || (writeLength != numBytesToWrite))
            {
                SetControls_Error("Error: Please check hardware and re-start application", Status);
                return 1;
            }

            numBytesToRead = 1;
            Status = FT260_I2CMaster_Read(ft260handle, (uint)Strip, FT260_I2C_FLAG.FT260_I2C_START_AND_STOP, pnt, numBytesToRead, ref readLength, 5000);

            if (Status == FT260_STATUS.FT260_OTHER_ERROR)
            {
                SetControls_Error("Please check hardware and re-start application", Status);
                return 1;
            }

            if (Status == FT260_STATUS.FT260_I2C_READ_FAIL)
            {
                SetControls_Error_AllowReInit("I2C failed", Status);
                return 1;
            }

            if ((Status != FT260_STATUS.FT260_OK) || (readLength != numBytesToRead))
            {
                SetControls_Error("Please check hardware and re-start application", Status);
                return 1;
            }

            Marshal.Copy(pnt, Reading, 0, (int)numBytesToRead);

            return Reading[0];
        }

        private byte ReadAllPCA9632Registers(LED_Strip_Type Strip)
        {
            // Read ALL registers of the PCA9632 LED Driver chip
            byte[] Reading = new byte[25];
            UInt32 writeLength = 0;
            UInt32 readLength = 0;
            UInt32 numBytesToRead = 0;
            UInt32 numBytesToWrite = 0;
            byte[] registers = new byte[20];

            int size = Marshal.SizeOf(registers[0]) * registers.Length;
            IntPtr pnt = Marshal.AllocHGlobal(size);

            // Set ControlReg to autoincrement
            registers[0] = 0x80;
            numBytesToWrite = 1;
            Marshal.Copy(registers, 0, pnt, registers.Length);
            Status = FT260_I2CMaster_Write(ft260handle, (uint)Strip, FT260_I2C_FLAG.FT260_I2C_START_AND_STOP, pnt, numBytesToWrite, ref writeLength);

            if ((Status != FT260_STATUS.FT260_OK) || (writeLength != numBytesToWrite))
            {
                SetControls_Error("Error: Please check hardware and re-start application", Status);
                return 1;
            }

            numBytesToRead = 13;
            Status = FT260_I2CMaster_Read(ft260handle, (uint)Strip, FT260_I2C_FLAG.FT260_I2C_START_AND_STOP, pnt, numBytesToRead, ref readLength, 5000);

            if (Status == FT260_STATUS.FT260_OTHER_ERROR)
            {
                SetControls_Error("Please check hardware and re-start application", Status);
                return 1;
            }

            if (Status == FT260_STATUS.FT260_I2C_READ_FAIL)
            {
                SetControls_Error_AllowReInit("I2C failed", Status);
                return 1;
            }

            if ((Status != FT260_STATUS.FT260_OK) || (readLength != numBytesToRead))
            {
                SetControls_Error("Please check hardware and re-start application", Status);
                return 1;
            }

            Marshal.Copy(pnt, Reading, 0, (int)numBytesToRead);

            return 0;
        }

        private void SetLedColor(LED_Strip_Type Strip, LED_STRIP_COLOR Color)
        {
            byte pca_color = 0;
            //byte led_out_state = PCA9632_LEDOUT.LDRx_ON;      // LED Driver fully on
            byte ledDrvState = (byte)PCA9632_LEDOUT.LDRx_GRPPWM;    // Group PWM mode

            // map colors to output drivers
            byte Red = (byte)(ledDrvState << 2);
            byte Green = ledDrvState;
            byte Blue = (byte)(ledDrvState << 4);


            switch (Color)
            {
                case LED_STRIP_COLOR.RED:
                    pca_color = Red;
                    break;
                case LED_STRIP_COLOR.GREEN:
                    pca_color = Green;
                    break;
                case LED_STRIP_COLOR.BLUE:
                    pca_color = Blue;
                    break;
                case LED_STRIP_COLOR.WHITE:
                    // All RGB on (LDRx= 0001 0101 = 0x15)
                    pca_color = (byte)(Red | Green | Blue);
                    break;
                case LED_STRIP_COLOR.YELLOW:
                    // R+G on 
                    pca_color = (byte)(Red | Green);
                    break;
                case LED_STRIP_COLOR.CYAN:
                    // G+B on  0001 0001 = 0x11;
                    pca_color = (byte)(Green | Blue);
                    break;
                case LED_STRIP_COLOR.MAGENTA:
                    // R+B on  0001 0100 = 0x14;
                    pca_color = (byte)(Red | Blue);
                    break;

                case LED_STRIP_COLOR.OFF:
                default:
                    pca_color = 0x00;
                    break;
            }

            // Set LEDOUT (08h) to turn on specific LED
            if (WritePCA9632Register(Strip, 0x08, pca_color) == 1)
            {
                return;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Cycle through the Front Light values.
            ++Front_LED_cycle;
            switch (Front_LED_cycle)
            {
                case 1:
                    SetLedColor(LED_Strip_Type.LED_STRIP_FRONT, LED_STRIP_COLOR.RED);
                    labelStatus.Text = "Front: Red";
                    break;
                case 2:
                    SetLedColor(LED_Strip_Type.LED_STRIP_FRONT, LED_STRIP_COLOR.GREEN);
                    labelStatus.Text = "Front: Green";
                    break;
                case 3:
                    // set BLUE
                    SetLedColor(LED_Strip_Type.LED_STRIP_FRONT, LED_STRIP_COLOR.BLUE);
                    labelStatus.Text = "Front: Blue";
                    break;
                case 4:
                    SetLedColor(LED_Strip_Type.LED_STRIP_FRONT, LED_STRIP_COLOR.WHITE);
                    labelStatus.Text = "Front: White";
                    break;
                case 5:
                    SetLedColor(LED_Strip_Type.LED_STRIP_FRONT, LED_STRIP_COLOR.YELLOW);
                    labelStatus.Text = "Front: Yellow";
                    break;
                case 6:
                    SetLedColor(LED_Strip_Type.LED_STRIP_FRONT, LED_STRIP_COLOR.CYAN);
                    labelStatus.Text = "Front: Cyan";
                    break;
                case 7:
                    SetLedColor(LED_Strip_Type.LED_STRIP_FRONT, LED_STRIP_COLOR.MAGENTA);
                    labelStatus.Text = "Front: Magenta";
                    break;

                default:
                    SetLedColor(LED_Strip_Type.LED_STRIP_FRONT, LED_STRIP_COLOR.OFF);
                    Front_LED_cycle = 0;    // reset cycle counter
                    labelStatus.Text = "Front: Off";
                    break;
            }

            // Debug Read ALL registers of the PCA9632 LED Driver chip
            //ReadPCA9632Registers(LED_Strip_Type.LED_STRIP_FRONT);

        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            // Audio mute/unmute
            if (checkBox2.Checked)
            {
                Status = FT260_GPIO_Write(ft260handle, FT260_GPIO.FT260_GPIO_H, 0);    // Set 0 to mute
            }
            else
            {
                Status = FT260_GPIO_Write(ft260handle, FT260_GPIO.FT260_GPIO_H, 1);    // Set 1 to unmute
            }

            if (Status != FT260_STATUS.FT260_OK)
            {
                labelStatus.Text = "Error changing mute operation";
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Audio Amplifier On/Off
            if (checkBox1.Checked)
            {
                Status = FT260_GPIO_Write(ft260handle, FT260_GPIO.FT260_GPIO_2, 0);    // Set 0 to Enable Audio amp
            }
            else
            {
                Status = FT260_GPIO_Write(ft260handle, FT260_GPIO.FT260_GPIO_2, 1);    // Set 1 to Disable Audio Amp
            }

            if (Status != FT260_STATUS.FT260_OK)
            {
                labelStatus.Text = "Error changing mute operation";
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cycle through the Rear Light values.
            ++Rear_LED_cycle;
            switch (Rear_LED_cycle)
            {
                case 1:
                    SetLedColor(LED_Strip_Type.LED_STRIP_REAR, LED_STRIP_COLOR.RED);
                    labelStatus.Text = "Rear: Red";
                    break;
                case 2:
                    SetLedColor(LED_Strip_Type.LED_STRIP_REAR, LED_STRIP_COLOR.GREEN);
                    labelStatus.Text = "Rear: Green";
                    break;
                case 3:
                    SetLedColor(LED_Strip_Type.LED_STRIP_REAR, LED_STRIP_COLOR.BLUE);
                    labelStatus.Text = "Rear: Blue";
                    break;
                case 4:
                    SetLedColor(LED_Strip_Type.LED_STRIP_REAR, LED_STRIP_COLOR.WHITE);
                    labelStatus.Text = "Rear: White";
                    break;
                case 5:
                    SetLedColor(LED_Strip_Type.LED_STRIP_REAR, LED_STRIP_COLOR.YELLOW);
                    labelStatus.Text = "Rear: Yello";
                    break;
                case 6:
                    SetLedColor(LED_Strip_Type.LED_STRIP_REAR, LED_STRIP_COLOR.CYAN);
                    labelStatus.Text = "Rear: Cyan";
                    break;
                case 7:
                    SetLedColor(LED_Strip_Type.LED_STRIP_REAR, LED_STRIP_COLOR.MAGENTA);
                    labelStatus.Text = "Rear: Magenta";
                    break;

                default:
                    SetLedColor(LED_Strip_Type.LED_STRIP_REAR, LED_STRIP_COLOR.OFF);
                    Rear_LED_cycle = 0;    // reset cycle counter
                    labelStatus.Text = "Rear: Off";
                    break;
            }

        }

        private void FrontnumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Change Front brightness Global indicator-
            byte value = (byte)FrontnumericUpDown1.Value;
            Front_GRPPWM = (byte)(value << 4);
            if (WritePCA9632Register(LED_Strip_Type.LED_STRIP_FRONT, 0x06, Front_GRPPWM) == 1)
            {
                return;
            }
        }

        private void RearnumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Change Rear brightness Global indicator-
            byte value = (byte) RearnumericUpDown1.Value;
            Rear_GRPPWM = (byte)(value << 0x04);
            if (WritePCA9632Register(LED_Strip_Type.LED_STRIP_REAR, 0x06, Rear_GRPPWM) == 1)
            {
                return;
            }
        }
    }

}
