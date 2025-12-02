using NUnit.Framework;
using System;

namespace Television.Tests
{
    public class TelevisionDeviceTests
    {
        private TelevisionDevice tv;

        [SetUp]
        public void Setup()
        {
            tv = new TelevisionDevice("Samsung", 999.99, 1920, 1080);
        }

        
        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            Assert.AreEqual("Samsung", tv.Brand);
            Assert.AreEqual(999.99, tv.Price);
            Assert.AreEqual(1920, tv.ScreenWidth);
            Assert.AreEqual(1080, tv.ScreenHeigth);

            Assert.AreEqual(0, tv.CurrentChannel);
            Assert.AreEqual(13, tv.Volume);
            Assert.IsFalse(tv.IsMuted);
        }

        
        [Test]
        public void SwitchOn_ShouldReturnCorrectString_WhenNotMuted()
        {
            string result = tv.SwitchOn();
            Assert.AreEqual("Cahnnel 0 - Volume 13 - Sound On", result);
        }

        [Test]
        public void SwitchOn_ShouldReturnCorrectString_WhenMuted()
        {
            tv.MuteDevice();
            string result = tv.SwitchOn();
            Assert.AreEqual("Cahnnel 0 - Volume 13 - Sound Off", result);
        }

        
        [Test]
        public void ChangeChannel_ShouldChangeChannel_WhenValid()
        {
            int result = tv.ChangeChannel(5);

            Assert.AreEqual(5, result);
            Assert.AreEqual(5, tv.CurrentChannel);
        }

        [Test]
        public void ChangeChannel_ShouldThrowException_WhenChannelIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                tv.ChangeChannel(-1);
            });
        }

        
        [Test]
        public void VolumeChange_ShouldIncreaseVolume_WhenDirectionIsUP()
        {
            tv.VolumeChange("UP", 10);
            Assert.AreEqual(23, tv.Volume);
        }

        [Test]
        public void VolumeChange_ShouldDecreaseVolume_WhenDirectionIsDOWN()
        {
            tv.VolumeChange("DOWN", 5);
            Assert.AreEqual(8, tv.Volume);
        }

        [Test]
        public void VolumeChange_ShouldNotExceed100()
        {
            tv.VolumeChange("UP", 500);
            Assert.AreEqual(100, tv.Volume);
        }

        [Test]
        public void VolumeChange_ShouldNotGoBelow0()
        {
            tv.VolumeChange("DOWN", 500);
            Assert.AreEqual(0, tv.Volume);
        }

        
        [Test]
        public void MuteDevice_ShouldMute_WhenCurrentlyNotMuted()
        {
            bool result = tv.MuteDevice();
            Assert.IsTrue(result);
            Assert.IsTrue(tv.IsMuted);
        }

        [Test]
        public void MuteDevice_ShouldUnmute_WhenCurrentlyMuted()
        {
            tv.MuteDevice(); 
            bool result = tv.MuteDevice(); 

            Assert.IsFalse(result);
            Assert.IsFalse(tv.IsMuted);
        }

        
        [Test]
        public void ToString_ShouldReturnCorrectFormat()
        {
            string result = tv.ToString();
            Assert.AreEqual("TV Device: Samsung, Screen Resolution: 1920x1080, Price 999.99$", result);
        }
    }
}
