-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 29 Agu 2026 pada 15.28
-- Versi server: 10.4.32-MariaDB
-- Versi PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_bell`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `admin`
--

CREATE TABLE `admin` (
  `ida` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `ConfrmPassword` varchar(200) NOT NULL,
  `Nama_Admin` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `admin`
--

INSERT INTO `admin` (`ida`, `Username`, `Password`, `ConfrmPassword`, `Nama_Admin`) VALUES
(1, 'A', '1', '1', 'ami');

-- --------------------------------------------------------

--
-- Struktur dari tabel `jadwal_bel`
--

CREATE TABLE `jadwal_bel` (
  `idj` int(11) NOT NULL,
  `Nama_bel` varchar(100) NOT NULL,
  `jam` time NOT NULL,
  `Keterangan` varchar(255) DEFAULT NULL,
  `Status` enum('Aktif','Nonaktif') DEFAULT 'Aktif'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `jadwal_bel`
--

INSERT INTO `jadwal_bel` (`idj`, `Nama_bel`, `jam`, `Keterangan`, `Status`) VALUES
(1, 'Bel Masuk', '07:00:00', 'Siswa masuk sekolah', 'Aktif'),
(2, 'Jam Pelajaran 1', '08:00:00', 'Pergantian pelajaran', 'Aktif'),
(3, 'Istirahat', '10:00:00', 'Waktu istirahat', 'Aktif'),
(4, 'Masuk Setelah Istirahat', '10:30:00', 'Siswa kembali ke kelas', 'Aktif'),
(5, 'Bel Pulang', '13:00:00', 'Kegiatan sekolah selesai', 'Aktif');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pengaturan`
--

CREATE TABLE `pengaturan` (
  `idp` int(11) NOT NULL,
  `Nama_Sekolah` varchar(150) DEFAULT NULL,
  `Volume` int(11) DEFAULT 100,
  `File_Suara` varchar(255) DEFAULT NULL,
  `Durasi_Bel` int(11) DEFAULT 5
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `pengaturan`
--

INSERT INTO `pengaturan` (`idp`, `Nama_Sekolah`, `Volume`, `File_Suara`, `Durasi_Bel`) VALUES
(1, 'SMK', 100, 'bel.mp3', 5);

-- --------------------------------------------------------

--
-- Struktur dari tabel `riwayat_bel`
--

CREATE TABLE `riwayat_bel` (
  `idr` int(11) NOT NULL,
  `idj` int(11) NOT NULL,
  `Waktu_Bunyi` datetime NOT NULL,
  `Keterangan` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `user`
--

CREATE TABLE `user` (
  `idu` int(11) NOT NULL,
  `username` varchar(200) NOT NULL,
  `password` varchar(200) NOT NULL,
  `confrmpassword` varchar(200) NOT NULL,
  `nama` varchar(200) NOT NULL,
  `alamat` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`ida`),
  ADD UNIQUE KEY `Username` (`Username`);

--
-- Indeks untuk tabel `jadwal_bel`
--
ALTER TABLE `jadwal_bel`
  ADD PRIMARY KEY (`idj`);

--
-- Indeks untuk tabel `pengaturan`
--
ALTER TABLE `pengaturan`
  ADD PRIMARY KEY (`idp`);

--
-- Indeks untuk tabel `riwayat_bel`
--
ALTER TABLE `riwayat_bel`
  ADD PRIMARY KEY (`idr`),
  ADD KEY `idj` (`idj`);

--
-- Indeks untuk tabel `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`idu`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `admin`
--
ALTER TABLE `admin`
  MODIFY `ida` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT untuk tabel `jadwal_bel`
--
ALTER TABLE `jadwal_bel`
  MODIFY `idj` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT untuk tabel `pengaturan`
--
ALTER TABLE `pengaturan`
  MODIFY `idp` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT untuk tabel `riwayat_bel`
--
ALTER TABLE `riwayat_bel`
  MODIFY `idr` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `user`
--
ALTER TABLE `user`
  MODIFY `idu` int(11) NOT NULL AUTO_INCREMENT;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `riwayat_bel`
--
ALTER TABLE `riwayat_bel`
  ADD CONSTRAINT `riwayat_bel_ibfk_1` FOREIGN KEY (`idj`) REFERENCES `jadwal_bel` (`idj`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
