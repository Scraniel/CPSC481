﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using RadBox_start.Pages;
using RadBox_start.DataClasses;

namespace RadBox_start.Helpers
{
    public static class Navigator
    {
        public static Frame MainWindowFrame;
        private static LandingPage landingPage = new LandingPage();
        private static MoviesAndShowsPage moviesAndShowsPage = new MoviesAndShowsPage();
        private static PicturesPage picturesPage = new PicturesPage();
        private static PictureFullscreen picFullScreen = new PictureFullscreen();
        private static MoviesAndShowsFullscreen moviesAndShowsFullscreen = new MoviesAndShowsFullscreen();

        private static void Navigate(Page navigateTo)
        {
            MainWindowFrame.Navigate(navigateTo);
        }

        public static void LandingPage()
        {
            Navigate(landingPage);
        }

        public static void MoviesAndShowsPage()
        {
            Navigate(moviesAndShowsPage);
        }

        public static void MoviesAndShowsPage(bool watched, TimeSpan position)
        {
            moviesAndShowsPage.UpdateMetaData(watched, position);
            Navigate(moviesAndShowsPage);
        }

        public static void PicturesPage()
        {
            Navigate(picturesPage);
        }

        public static void PictureFullScreen()
        {
            Navigate(picFullScreen);
        }

        public static void PictureFullScreen(PicturesData data)
        {
            picFullScreen.DataContext = data;
            PictureFullScreen();
            picFullScreen.dispatcherTimer.Start();
        }

        public static void MoviesAndShowsFullscreen(int index, TimeSpan position, MoviesAndShowsData.MovieType type)
        {
            moviesAndShowsFullscreen.data.SetCurrentlyPlaying(index, type);
            moviesAndShowsFullscreen.Video.Source = new Uri(moviesAndShowsFullscreen.data.CurrentlyPlaying, UriKind.Relative);
            moviesAndShowsFullscreen.Video.Position = position;
            Navigate(moviesAndShowsFullscreen);
        }
    }
}
