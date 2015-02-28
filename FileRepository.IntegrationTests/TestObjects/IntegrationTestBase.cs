using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FileRepository.IntegrationTests.TestObjects
{
    [TestClass]
    public class IntegrationTestBase
    {
        protected const string Integration = "Integration";

        protected const string _testFile = @"D:\testing\Ride\Going Blank Again\01 - Leave Them All Behind.mp3";
        protected const string _testCopyFile = @"D:\testing\testCopy.mp3";
        protected const string _testMoveFile = @"D:\testing\testMove.mp3";
        protected const string _testDestFile = @"D:\testing\testDest.mp3";
        protected const string _testSaveFile = @"D:\testing\testSave.mp3";
        
        protected const string _collectionDirectory = @"d:\testing\";

        protected const string _testFolderNoFiles = @"D:\testing\Ride";
        protected const string _testFolderHasFiles = @"D:\testing\Ride\Going Blank Again";


        protected static void CleanUp()
        {
            if (File.Exists(_testCopyFile)) File.Delete(_testCopyFile);
            if (File.Exists(_testMoveFile)) File.Delete(_testMoveFile);
            if (File.Exists(_testDestFile)) File.Delete(_testDestFile);
            if (File.Exists(_testSaveFile)) File.Delete(_testSaveFile);
        } 
        
    }
}
