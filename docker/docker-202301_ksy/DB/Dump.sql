-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: game_db
-- ------------------------------------------------------
-- Server version	8.2.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

CREATE DATABASE `log_db`;
USE `log_db`;

-- DROP TABLE IF EXISTS `log`;
-- CREATE TABLE `log` (
--  `seq` int NOT NULL AUTO_INCREMENT COMMENT '로그 일련번호',
--  `level` varchar(20) NOT NULL COMMENT '로그 타입',
--  `timestamp` datetime NOT NULL COMMENT '로그 일시',
--  `msg` varchar(2048) NOT NULL COMMENT '로그 메시지',
--  PRIMARY KEY (`seq`)
-- ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='로그 테이블';

DROP TABLE IF EXISTS `info_api_log`;
CREATE TABLE `info_api_log` (
  `seq` int NOT NULL AUTO_INCREMENT COMMENT '일련번호',
  `level` varchar(20) NOT NULL COMMENT '레벨',
  `timestamp` datetime NOT NULL COMMENT '일시',
  `api` varchar(40) NOT NULL COMMENT 'API 명',
  `uid` int NOT NULL COMMENT 'UID',
  `result` int NOT NULL COMMENT 'API 결과',
  PRIMARY KEY (`seq`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='API 정보 로그 테이블';

DROP TABLE IF EXISTS `info_login_log`;
CREATE TABLE `info_login_log` (
  `seq` int NOT NULL AUTO_INCREMENT COMMENT '일련번호',
  `level` varchar(20) NOT NULL COMMENT '레벨',
  `timestamp` datetime NOT NULL COMMENT '일시',
  `api` varchar(40) NOT NULL COMMENT 'API 명',
  `uid` int NOT NULL COMMENT 'UID',
  `player_id` bigint NOT NULL COMMENT '플레이어 ID',
  `result` int NOT NULL COMMENT 'API 결과',
  PRIMARY KEY (`seq`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='로그인 정보 로그 테이블';

DROP TABLE IF EXISTS `info_game_log`;
CREATE TABLE `info_game_log` (
  `seq` int NOT NULL AUTO_INCREMENT COMMENT '일련번호',
  `level` varchar(20) NOT NULL COMMENT '레벨',
  `timestamp` datetime NOT NULL COMMENT '일시',
  `api` varchar(40) NOT NULL COMMENT 'API 명',
  `uid` int NOT NULL COMMENT 'UID',
  `game_key` int NOT NULL COMMENT '게임 키',
  `score` int NOT NULL COMMENT '점수',
  `result` int NOT NULL COMMENT 'API 결과',
  PRIMARY KEY (`seq`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='게임 정보 로그 테이블';


DROP TABLE IF EXISTS `error_log`;
CREATE TABLE `error_log` (
  `seq` int NOT NULL AUTO_INCREMENT COMMENT '일련번호',
  `level` varchar(20) NOT NULL COMMENT '레벨',
  `timestamp` datetime NOT NULL COMMENT '일시',
  `msg` varchar(2048) NOT NULL COMMENT '메시지',
  PRIMARY KEY (`seq`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='error 로그 테이블';
--
-- Current Database: `game_db`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `game_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `game_db`;

--
-- Table structure for table `friend`
--

DROP TABLE IF EXISTS `friend`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `friend` (
  `uid` int NOT NULL COMMENT '유저아이디',
  `friend_uid` int NOT NULL COMMENT '친구 유저아이디',
  `friend_yn` tinyint NOT NULL DEFAULT '0' COMMENT '친구 여부',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  PRIMARY KEY (`uid`,`friend_uid`),
  KEY `FK_friend_friend_uid_user_info_uid` (`friend_uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `friend`
--

LOCK TABLES `friend` WRITE;
/*!40000 ALTER TABLE `friend` DISABLE KEYS */;
INSERT INTO `friend` VALUES (4,5,0,'2024-01-17 13:29:59'),(6,5,0,'2024-01-17 18:04:09'),(9,5,0,'2024-01-19 15:58:42'),(13,17,0,'2024-01-23 15:56:27'),(14,5,0,'2024-01-23 10:40:36'),(14,17,1,'2024-01-23 15:50:49'),(17,8,0,'2024-01-23 15:48:29'),(17,14,1,'2024-01-23 15:34:53');
/*!40000 ALTER TABLE `friend` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mailbox`
--

DROP TABLE IF EXISTS `mailbox`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mailbox` (
  `mail_seq` int NOT NULL AUTO_INCREMENT COMMENT '우편 일련번호',
  `uid` int NOT NULL COMMENT '유저아이디',
  `mail_title` varchar(100) NOT NULL COMMENT '우편 제목',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  `expire_dt` datetime NOT NULL COMMENT '만료 일시',
  `receive_dt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '수령 일시',
  `receive_yn` tinyint NOT NULL DEFAULT '0' COMMENT '수령 유무',
  PRIMARY KEY (`mail_seq`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='우편함';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mailbox`
--

LOCK TABLES `mailbox` WRITE;
/*!40000 ALTER TABLE `mailbox` DISABLE KEYS */;
INSERT INTO `mailbox` VALUES (2,13,'두 번째 접속 선물!!!','2024-01-18 13:58:44','2024-02-01 13:58:44','2024-01-23 11:28:00',1),(3,8,'세 번째 접속 선물!!!','2024-01-18 13:58:52','2024-02-01 13:58:52','2024-01-23 11:22:31',0),(4,13,'첫 번째 접속 선물','2024-01-19 15:54:07','2024-02-02 15:54:07','2024-01-23 11:52:04',1),(5,9,'첫 번째 접속 선물','2024-01-19 15:54:21','2024-01-19 15:54:21','2024-01-23 11:22:31',0);
/*!40000 ALTER TABLE `mailbox` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mailbox_reward`
--

DROP TABLE IF EXISTS `mailbox_reward`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mailbox_reward` (
  `mail_seq` int NOT NULL COMMENT '우편 일련번호',
  `reward_key` int NOT NULL COMMENT '보상 키',
  `reward_qty` int NOT NULL COMMENT '보상 수',
  `reward_type` varchar(20) NOT NULL COMMENT '보상 타입',
  PRIMARY KEY (`mail_seq`,`reward_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='우편함 보상';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mailbox_reward`
--

LOCK TABLES `mailbox_reward` WRITE;
/*!40000 ALTER TABLE `mailbox_reward` DISABLE KEYS */;
INSERT INTO `mailbox_reward` VALUES (2,1,100,'money'),(2,1001,1,'char'),(2,4001,5,'food'),(2,4101,5,'food_gear'),(2,5001,1,'gacha'),(3,1,100,'money'),(3,1001,1,'char'),(3,5001,1,'gacha'),(4,1,100,'money'),(4,1003,1,'char'),(4,5002,1,'gacha');
/*!40000 ALTER TABLE `mailbox_reward` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `uid` int NOT NULL AUTO_INCREMENT COMMENT '유저아이디',
  `player_id` bigint NOT NULL COMMENT '플레이어 아이디',
  `create_dt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '생성 일시',
  `recent_login_dt` datetime DEFAULT NULL COMMENT '최근 로그인 일시',
  `nickname` varchar(50) NOT NULL,
  `total_bestscore` int DEFAULT NULL,
  `total_bestscore_cur_season` int DEFAULT NULL,
  `total_bestscore_prev_season` int DEFAULT NULL,
  `star_point` int NOT NULL DEFAULT '0' COMMENT '스타 포인트',
  `main_char_key` int NOT NULL DEFAULT '1' COMMENT '대표 캐릭터 키',
  PRIMARY KEY (`uid`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (4,16,'2024-01-16 18:01:17','2024-01-17 13:29:15','a',1000,0,0,0,1001),(5,17,'2024-01-16 18:02:53','2024-01-16 18:02:53','b',1000,0,0,0,1001),(6,18,'2024-01-17 14:02:09','2024-01-17 18:03:50','ksy',1000,0,0,0,1001),(7,19,'2024-01-18 09:25:18','2024-01-18 09:25:18','sykim',1000,0,0,0,1001),(8,20,'2024-01-18 09:27:30','2024-01-22 15:21:27','sy',1000,0,0,0,1001),(9,21,'2024-01-19 15:49:39','2024-01-22 16:17:14','sy1',10000,0,0,0,1003),(13,22,'2024-01-22 18:01:28','2024-01-23 15:56:18','sya1',0,0,0,0,1001),(14,23,'2024-01-22 18:04:29','2024-01-24 09:39:21','syaa1',0,0,0,0,1001),(17,24,'2024-01-23 12:15:13','2024-01-23 17:07:06','syaaa1',100001,0,0,0,1001),(21,26,'2024-01-23 17:38:59','2024-01-24 09:38:20','26번입니다람쥐',10001,NULL,NULL,0,1001),(22,27,'2024-01-24 11:11:17','2024-01-24 14:22:58','테스트',2000,NULL,NULL,0,1001),(23,28,'2024-01-24 14:25:41','2024-01-24 14:27:28','aadsaa',NULL,NULL,NULL,0,1001),(24,29,'2024-01-24 14:28:43','2024-01-25 13:55:28','bbbb',NULL,NULL,NULL,0,1001);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_attendance`
--

DROP TABLE IF EXISTS `user_attendance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_attendance` (
  `uid` int NOT NULL COMMENT '유저아이디',
  `attendance_cnt` int NOT NULL DEFAULT '0' COMMENT '출석 횟수',
  `recent_attendance_dt` datetime DEFAULT NULL COMMENT '최근 출석 일시',
  PRIMARY KEY (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='출석 테이블';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_attendance`
--

LOCK TABLES `user_attendance` WRITE;
/*!40000 ALTER TABLE `user_attendance` DISABLE KEYS */;
INSERT INTO `user_attendance` VALUES (6,0,'2024-01-18 11:11:11'),(7,0,'2024-01-18 11:11:11'),(8,14,'2024-01-19 14:02:17'),(9,1,'2024-01-19 15:50:27'),(13,1,'2024-01-23 11:37:41'),(14,0,'2024-01-18 11:11:11'),(17,0,'2024-01-22 12:15:13'),(21,1,'2024-01-23 17:39:29'),(22,1,'2024-01-24 11:12:44'),(23,0,'2024-01-23 14:25:41'),(24,7,'2024-01-24 14:36:45');
/*!40000 ALTER TABLE `user_attendance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_char`
--

DROP TABLE IF EXISTS `user_char`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_char` (
  `uid` int NOT NULL COMMENT '유저아이디',
  `char_key` int NOT NULL,
  `char_level` int NOT NULL DEFAULT '1' COMMENT '캐릭터 레벨',
  `skin_key` int NOT NULL DEFAULT '0' COMMENT '스킨 키',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  `costume_json` json NOT NULL COMMENT '코스튬 JSON',
  `char_cnt` int NOT NULL DEFAULT '1' COMMENT '캐릭터 개수',
  PRIMARY KEY (`uid`,`char_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_char`
--

LOCK TABLES `user_char` WRITE;
/*!40000 ALTER TABLE `user_char` DISABLE KEYS */;
INSERT INTO `user_char` VALUES (8,1001,7,0,'2024-01-18 18:40:18','{\"face\": 0, \"hand\": 0, \"head\": 0}',22),(9,1001,1,0,'2024-01-19 16:25:57','{\"face\": 0, \"hand\": 0, \"head\": 0}',1),(9,1003,1,0,'2024-01-19 15:57:25','{\"face\": 0, \"hand\": 0, \"head\": 0}',1),(13,1001,2,0,'2024-01-22 18:01:28','{\"face\": 0, \"hand\": 0, \"head\": 0}',2),(13,1003,1,0,'2024-01-23 11:52:03','{\"face\": 0, \"hand\": 0, \"head\": 0}',1),(14,1001,1,0,'2024-01-22 18:04:29','{\"face\": 0, \"hand\": 0, \"head\": 0}',1),(17,1001,1,0,'2024-01-23 12:15:13','{\"face\": 0, \"hand\": 0, \"head\": 0}',1),(21,1001,1,0,'2024-01-23 17:38:59','{\"face\": 0, \"hand\": 0, \"head\": 0}',1),(22,1001,1,0,'2024-01-24 11:11:17','{\"face\": 0, \"hand\": 0, \"head\": 0}',1),(23,1,1,0,'2024-01-24 14:25:41','{\"face\": 0, \"hand\": 0, \"head\": 0}',1),(24,1,1,0,'2024-01-24 14:28:43','{\"face\": 0, \"hand\": 0, \"head\": 0}',1);
/*!40000 ALTER TABLE `user_char` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_char_random_skill`
--

DROP TABLE IF EXISTS `user_char_random_skill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_char_random_skill` (
  `uid` int NOT NULL COMMENT '유저아이디',
  `char_key` int NOT NULL COMMENT '캐릭터 키',
  `index_num` int NOT NULL COMMENT '순서 숫자',
  `skill_key` int NOT NULL COMMENT '스킬 키',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  PRIMARY KEY (`uid`,`char_key`,`index_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='유저 캐릭터 랜덤 스킬';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_char_random_skill`
--

LOCK TABLES `user_char_random_skill` WRITE;
/*!40000 ALTER TABLE `user_char_random_skill` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_char_random_skill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_costume`
--

DROP TABLE IF EXISTS `user_costume`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_costume` (
  `uid` int NOT NULL COMMENT '유저아이디',
  `costume_key` int NOT NULL,
  `costume_level` int NOT NULL DEFAULT '1' COMMENT '코스튬 레벨',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  `costume_cnt` int NOT NULL DEFAULT '1' COMMENT '코스튬 개수',
  PRIMARY KEY (`uid`,`costume_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_costume`
--

LOCK TABLES `user_costume` WRITE;
/*!40000 ALTER TABLE `user_costume` DISABLE KEYS */;
INSERT INTO `user_costume` VALUES (8,3001,1,'2024-01-19 13:35:27',1),(8,3002,2,'2024-01-19 13:56:46',2),(8,3003,2,'2024-01-19 13:50:34',2),(8,3004,2,'2024-01-19 13:25:52',2),(8,3005,3,'2024-01-19 13:55:07',3),(8,3006,1,'2024-01-19 14:02:18',1),(8,3010,1,'2024-01-19 13:35:27',1),(9,3005,1,'2024-01-19 15:57:25',1),(9,3007,1,'2024-01-19 15:57:25',1),(9,3009,1,'2024-01-19 15:57:25',1),(13,3002,1,'2024-01-23 11:52:03',1),(13,3003,1,'2024-01-23 11:52:03',1),(13,3007,1,'2024-01-23 11:28:00',1),(13,3009,1,'2024-01-23 11:28:00',1),(24,4,1,'2024-01-24 14:36:45',1),(24,7,2,'2024-01-24 14:35:41',2),(24,9,1,'2024-01-24 14:35:41',1),(24,10,1,'2024-01-24 14:36:39',1);
/*!40000 ALTER TABLE `user_costume` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_food`
--

DROP TABLE IF EXISTS `user_food`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_food` (
  `uid` int NOT NULL COMMENT '유저아이디',
  `food_key` int NOT NULL COMMENT '푸드 키',
  `food_qty` int NOT NULL DEFAULT '0' COMMENT '푸드 수',
  `food_gear_qty` int NOT NULL DEFAULT '0' COMMENT '푸드 기어 수',
  `food_level` int NOT NULL DEFAULT '1' COMMENT '푸드 레벨',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  PRIMARY KEY (`uid`,`food_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='푸드 정보 테이블';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_food`
--

LOCK TABLES `user_food` WRITE;
/*!40000 ALTER TABLE `user_food` DISABLE KEYS */;
INSERT INTO `user_food` VALUES (8,4001,20,20,1,'2024-01-19 13:56:21'),(8,4002,3,0,1,'2024-01-19 13:56:46'),(8,4007,1,0,1,'2024-01-19 13:56:32'),(8,4008,1,0,1,'2024-01-19 13:56:32'),(8,4009,2,0,1,'2024-01-19 13:57:44'),(8,4012,1,0,1,'2024-01-19 14:02:18'),(8,4013,1,0,1,'2024-01-19 13:56:21'),(8,4014,1,0,1,'2024-01-19 13:56:21'),(8,4016,3,0,1,'2024-01-19 13:56:46'),(8,4017,1,0,1,'2024-01-19 14:02:18'),(9,4001,1,0,1,'2024-01-19 15:57:25'),(9,4004,1,0,1,'2024-01-19 15:57:25'),(9,4007,1,0,1,'2024-01-19 15:57:25'),(9,4012,1,0,1,'2024-01-19 15:57:25'),(9,4018,1,0,1,'2024-01-19 15:57:25'),(13,4001,5,5,1,'2024-01-23 11:28:00'),(13,4003,2,0,1,'2024-01-23 11:52:03'),(13,4005,2,0,1,'2024-01-23 11:28:00'),(13,4010,2,0,1,'2024-01-23 11:52:03'),(13,4016,1,0,1,'2024-01-23 11:52:03'),(24,11,1,0,1,'2024-01-24 14:36:45'),(24,13,1,0,1,'2024-01-24 14:36:45'),(24,14,1,0,1,'2024-01-24 14:35:41'),(24,16,1,0,1,'2024-01-24 14:36:39');
/*!40000 ALTER TABLE `user_food` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_minigame`
--

DROP TABLE IF EXISTS `user_minigame`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_minigame` (
  `uid` int NOT NULL COMMENT '유저아이디',
  `game_key` int NOT NULL,
  `bestscore` int NOT NULL DEFAULT '0',
  `bestscore_cur_season` int NOT NULL DEFAULT '0' COMMENT '최고점수 현재 시즌',
  `bestscore_prev_season` int NOT NULL DEFAULT '0' COMMENT '최고점수 이전 시즌',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  `new_record_dt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '신기록 일시',
  `recent_play_dt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '최근 플레이 일시',
  `play_char_key` int DEFAULT NULL,
  PRIMARY KEY (`uid`,`game_key`),
  KEY `FK_game_game_id_game_info_game_id` (`game_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_minigame`
--

LOCK TABLES `user_minigame` WRITE;
/*!40000 ALTER TABLE `user_minigame` DISABLE KEYS */;
INSERT INTO `user_minigame` VALUES (4,1,0,0,0,'2024-01-16 18:01:16','2024-01-23 11:41:53','2024-01-23 11:41:53',1),(4,2,0,0,0,'2024-01-16 18:01:16','2024-01-23 11:41:53','2024-01-23 11:41:53',1),(4,3,0,0,0,'2024-01-16 18:01:16','2024-01-23 11:41:53','2024-01-23 11:41:53',1),(4,4,1000,1000,0,'2024-01-16 18:23:09','2024-01-23 11:41:53','2024-01-23 11:41:53',1),(4,5,1000,1000,0,'2024-01-17 13:30:35','2024-01-23 11:41:53','2024-01-23 11:41:53',1),(5,1,0,0,0,'2024-01-16 18:02:52','2024-01-23 11:41:59','2024-01-23 11:41:59',1),(5,2,0,0,0,'2024-01-16 18:02:52','2024-01-23 11:41:59','2024-01-23 11:41:59',1),(5,3,0,0,0,'2024-01-16 18:02:52','2024-01-23 11:41:59','2024-01-23 11:41:59',1),(6,1,0,0,0,'2024-01-17 14:02:08','2024-01-23 11:42:01','2024-01-23 11:42:01',1),(6,2,0,0,0,'2024-01-17 14:02:08','2024-01-23 11:42:01','2024-01-23 11:42:01',1),(6,3,0,0,0,'2024-01-17 14:02:08','2024-01-23 11:42:01','2024-01-23 11:42:01',1),(7,1,0,0,0,'2024-01-18 09:25:17','2024-01-23 11:42:07','2024-01-23 11:42:07',1),(7,2,0,0,0,'2024-01-18 09:25:17','2024-01-23 11:42:07','2024-01-23 11:42:07',1),(7,3,0,0,0,'2024-01-18 09:25:17','2024-01-23 11:42:07','2024-01-23 11:42:07',1),(8,1,0,0,0,'2024-01-18 09:27:30','2024-01-23 11:42:09','2024-01-23 11:42:09',1),(8,2,0,0,0,'2024-01-18 09:27:30','2024-01-23 11:42:09','2024-01-23 11:42:09',1),(8,3,0,0,0,'2024-01-18 09:27:30','2024-01-23 11:42:09','2024-01-23 11:42:09',1),(9,1,0,0,0,'2024-01-19 15:49:38','2024-01-23 11:42:11','2024-01-23 11:42:11',1001),(9,2,0,0,0,'2024-01-19 15:49:38','2024-01-23 11:42:11','2024-01-23 11:42:11',1001),(9,3,10000,10000,0,'2024-01-19 15:49:38','2024-01-23 11:42:11','2024-01-23 11:42:11',1003),(13,1,0,0,0,'2024-01-22 18:01:28','2024-01-23 11:42:19','2024-01-23 11:42:19',1001),(13,2,0,0,0,'2024-01-22 18:01:28','2024-01-23 11:42:19','2024-01-23 11:42:19',1001),(13,3,0,0,0,'2024-01-22 18:01:28','2024-01-23 11:42:19','2024-01-23 11:42:19',1001),(14,1,0,0,0,'2024-01-22 18:04:29','2024-01-23 11:42:20','2024-01-23 11:42:20',1001),(14,2,0,0,0,'2024-01-22 18:04:29','2024-01-23 11:42:20','2024-01-23 11:42:20',1001),(14,3,0,0,0,'2024-01-22 18:04:29','2024-01-23 11:42:20','2024-01-23 11:42:20',1001),(17,1,0,0,0,'2024-01-23 12:15:13','2024-01-23 12:15:13','2024-01-23 12:15:13',1001),(17,2,0,0,0,'2024-01-23 12:15:13','2024-01-23 12:15:13','2024-01-23 12:15:13',1001),(17,3,100001,100001,0,'2024-01-23 12:15:13','2024-01-23 17:21:15','2024-01-23 17:21:15',1001),(17,5,0,0,0,'2024-01-23 17:07:28','2024-01-23 17:07:28','2024-01-23 17:07:28',1001),(21,1,0,0,0,'2024-01-23 17:38:58','2024-01-23 17:38:58','2024-01-23 17:38:58',1001),(21,2,0,0,0,'2024-01-23 17:38:58','2024-01-23 17:38:58','2024-01-23 17:38:58',1001),(21,3,10001,10001,0,'2024-01-23 17:38:58','2024-01-23 17:43:01','2024-01-23 17:43:01',1001),(21,5,0,0,0,'2024-01-23 17:42:30','2024-01-23 17:42:30','2024-01-23 17:42:30',1001),(22,1,0,0,0,'2024-01-24 11:11:16','2024-01-24 11:11:16','2024-01-24 11:11:16',1001),(22,2,0,0,0,'2024-01-24 11:11:16','2024-01-24 11:11:16','2024-01-24 11:11:16',1001),(22,3,2000,2000,0,'2024-01-24 11:11:16','2024-01-24 11:15:55','2024-01-24 11:15:55',1001),(22,5,0,0,0,'2024-01-24 11:15:18','2024-01-24 11:15:17','2024-01-24 11:15:17',1001),(23,1,0,0,0,'2024-01-24 14:25:41','2024-01-24 14:25:41','2024-01-24 14:25:41',1),(23,2,0,0,0,'2024-01-24 14:25:41','2024-01-24 14:25:41','2024-01-24 14:25:41',1),(23,3,0,0,0,'2024-01-24 14:25:41','2024-01-24 14:25:41','2024-01-24 14:25:41',1),(24,1,0,0,0,'2024-01-24 14:28:55','2024-01-24 14:28:55','2024-01-24 14:28:55',1),(24,2,0,0,0,'2024-01-24 14:28:55','2024-01-24 14:28:55','2024-01-24 14:28:55',1),(24,3,0,0,0,'2024-01-24 14:28:55','2024-01-24 14:28:55','2024-01-24 14:28:55',1);
/*!40000 ALTER TABLE `user_minigame` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_money`
--

DROP TABLE IF EXISTS `user_money`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_money` (
  `uid` int NOT NULL COMMENT '유저아이디',
  `jewelry` int NOT NULL DEFAULT '0' COMMENT '보석',
  `gold_medal` int NOT NULL DEFAULT '0' COMMENT '금 메달',
  `cash` int NOT NULL DEFAULT '0' COMMENT '현금',
  `sunchip` int NOT NULL DEFAULT '0' COMMENT '썬칩',
  PRIMARY KEY (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_money`
--

LOCK TABLES `user_money` WRITE;
/*!40000 ALTER TABLE `user_money` DISABLE KEYS */;
INSERT INTO `user_money` VALUES (6,0,0,0,0),(7,0,0,0,0),(8,3400,0,0,0),(9,200,0,0,0),(13,300,0,0,0),(14,0,0,0,0),(17,0,0,0,0),(21,100,0,0,0),(22,100,0,0,0),(23,0,0,0,0),(24,600,0,0,0);
/*!40000 ALTER TABLE `user_money` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_skin`
--

DROP TABLE IF EXISTS `user_skin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_skin` (
  `uid` int NOT NULL COMMENT '유저아이디',
  `skin_key` int NOT NULL,
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  PRIMARY KEY (`uid`,`skin_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_skin`
--

LOCK TABLES `user_skin` WRITE;
/*!40000 ALTER TABLE `user_skin` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_skin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'game_db'
--

--
-- Dumping routines for database 'game_db'
--

--
-- Current Database: `master_db`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `master_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `master_db`;

--
-- Table structure for table `master_attendance_reward`
--

DROP TABLE IF EXISTS `master_attendance_reward`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `master_attendance_reward` (
  `day_seq` int NOT NULL COMMENT '날짜 번호',
  `reward_key` int NOT NULL COMMENT '보상 키',
  `reward_qty` int NOT NULL DEFAULT '0' COMMENT '보상 수',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  `reward_type` varchar(20) NOT NULL COMMENT '보상 종류',
  PRIMARY KEY (`day_seq`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='출석 보상 정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_attendance_reward`
--

LOCK TABLES `master_attendance_reward` WRITE;
/*!40000 ALTER TABLE `master_attendance_reward` DISABLE KEYS */;
INSERT INTO `master_attendance_reward` VALUES (1,1,100,'2024-01-17 15:14:00','money'),(2,1,100,'2024-01-17 15:14:00','money'),(3,1,100,'2024-01-17 15:14:00','money'),(4,1,100,'2024-01-17 15:14:00','money'),(5,1,100,'2024-01-17 15:14:00','money'),(6,1,100,'2024-01-17 15:14:00','money'),(7,1,1,'2024-01-17 15:14:00','gacha'),(8,1,100,'2024-01-17 15:14:00','money'),(9,1,100,'2024-01-17 15:14:00','money'),(10,1,100,'2024-01-17 15:14:00','money'),(11,1,100,'2024-01-17 15:14:00','money'),(12,1,100,'2024-01-17 15:14:00','money'),(13,1,100,'2024-01-17 15:14:00','money'),(14,2,1,'2024-01-17 15:14:00','gacha'),(15,1,100,'2024-01-17 15:14:00','money'),(16,1,100,'2024-01-17 15:14:00','money'),(17,1,100,'2024-01-17 15:14:00','money'),(18,1,100,'2024-01-17 15:14:00','money'),(19,1,100,'2024-01-17 15:14:00','money'),(20,1,100,'2024-01-17 15:14:00','money'),(21,3,1,'2024-01-17 15:14:00','gacha'),(22,1,100,'2024-01-17 15:14:00','money'),(23,1,100,'2024-01-17 15:14:00','money'),(24,1,100,'2024-01-17 15:14:00','money'),(25,1,100,'2024-01-17 15:14:00','money'),(26,1,100,'2024-01-17 15:14:00','money'),(27,1,100,'2024-01-17 15:14:00','money'),(28,3,3,'2024-01-17 15:14:00','gacha'),(29,1,1000,'2024-01-17 15:14:00','money'),(30,1,1000,'2024-01-17 15:14:00','money'),(31,1,1000,'2024-01-17 15:14:00','money');
/*!40000 ALTER TABLE `master_attendance_reward` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_char`
--

DROP TABLE IF EXISTS `master_char`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `master_char` (
  `char_key` int NOT NULL,
  `char_name` varchar(30) NOT NULL COMMENT '캐릭터 이름',
  `char_grade` varchar(10) NOT NULL COMMENT '캐릭터 등급',
  `stat_run` int NOT NULL COMMENT '달리기 스탯',
  `stat_power` int NOT NULL COMMENT '힘 스탯',
  `stat_jump` int NOT NULL COMMENT '점프 스탯',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  `game_key` int NOT NULL COMMENT '게임 키',
  PRIMARY KEY (`char_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_char`
--

LOCK TABLES `master_char` WRITE;
/*!40000 ALTER TABLE `master_char` DISABLE KEYS */;
INSERT INTO `master_char` VALUES (1,'그리','썬',6,4,7,'2024-01-15 11:31:00',1),(2,'양군','문',8,3,3,'2024-01-15 11:31:00',2),(3,'마카롱','스타',9,3,8,'2024-01-15 11:31:00',3);
/*!40000 ALTER TABLE `master_char` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_costume`
--

DROP TABLE IF EXISTS `master_costume`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `master_costume` (
  `costume_key` int NOT NULL,
  `costume_name` varchar(30) NOT NULL COMMENT '코스튬 이름',
  `costume_type` int NOT NULL COMMENT '코스튬 타입',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  `set_key` int DEFAULT NULL COMMENT '세트 키',
  PRIMARY KEY (`costume_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_costume`
--

LOCK TABLES `master_costume` WRITE;
/*!40000 ALTER TABLE `master_costume` DISABLE KEYS */;
INSERT INTO `master_costume` VALUES (1,'바람개비 모자',1,'2024-01-15 11:13:00',1),(2,'풍선껌',2,'2024-01-15 11:13:00',1),(3,'소용돌이 막대사탕',3,'2024-01-15 11:13:00',1),(4,'마법소녀 두건',1,'2024-01-15 11:13:00',2),(5,'마법소녀 티아라',2,'2024-01-15 11:13:00',2),(6,'마법소녀 마법책',3,'2024-01-15 11:13:00',2),(7,'마카롱의 체리 헤어',1,'2024-01-15 11:13:00',3),(8,'마카롱의 딸기 댄서',2,'2024-01-15 11:13:00',3),(9,'마카롱의 시상식 트로피',3,'2024-01-15 11:13:00',3),(10,'아기 모자',1,'2024-01-15 11:13:00',0);
/*!40000 ALTER TABLE `master_costume` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_costume_set`
--

DROP TABLE IF EXISTS `master_costume_set`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `master_costume_set` (
  `set_key` int NOT NULL,
  `char_key` int NOT NULL,
  `set_name` varchar(30) NOT NULL COMMENT '세트 이름',
  `set_bonus_percent` int NOT NULL COMMENT '세트 보너스 퍼센트',
  `char_bonus_percent` int NOT NULL COMMENT '캐릭터 보너스 점수 퍼센트',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  PRIMARY KEY (`set_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_costume_set`
--

LOCK TABLES `master_costume_set` WRITE;
/*!40000 ALTER TABLE `master_costume_set` DISABLE KEYS */;
INSERT INTO `master_costume_set` VALUES (1,1,'장난꾸러기 그리 세트',10,10,'2024-01-15 11:14:00'),(2,2,'마법소녀 양군 세트',10,10,'2024-01-15 11:14:00'),(3,3,'프로 아이돌 마카롱 세트',10,10,'2024-01-15 11:14:00');
/*!40000 ALTER TABLE `master_costume_set` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_food`
--

DROP TABLE IF EXISTS `master_food`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `master_food` (
  `food_key` int NOT NULL COMMENT '푸드 키',
  `food_name` varchar(50) NOT NULL COMMENT '푸드 이름',
  `game_key` int DEFAULT NULL,
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  PRIMARY KEY (`food_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='마스터 푸드';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_food`
--

LOCK TABLES `master_food` WRITE;
/*!40000 ALTER TABLE `master_food` DISABLE KEYS */;
INSERT INTO `master_food` VALUES (1,'콜라',1,'2024-01-17 14:24:00'),(2,'바나나',1,'2024-01-17 14:24:00'),(3,'파워워터',2,'2024-01-17 14:24:00'),(4,'사과',2,'2024-01-17 14:24:00'),(5,'무지개젤라또',3,'2024-01-17 14:24:00'),(6,'호두',3,'2024-01-17 14:24:00'),(7,'팝콘',4,'2024-01-17 14:24:00'),(8,'꿀호떡',4,'2024-01-17 14:24:00'),(9,'피자',5,'2024-01-17 14:24:00'),(10,'핫치킨라면',5,'2024-01-17 14:24:00'),(11,'키위',6,'2024-01-17 14:24:00'),(12,'쭈쭈바',6,'2024-01-17 14:24:00'),(13,'아이스커피',7,'2024-01-17 14:24:00'),(14,'포도',7,'2024-01-17 14:24:00'),(15,'딸기',8,'2024-01-17 14:24:00'),(16,'소라빵',8,'2024-01-17 14:24:00'),(17,'오렌지',9,'2024-01-17 14:24:00'),(18,'파티일면조',9,'2024-01-17 14:24:00'),(19,'고구마',10,'2024-01-17 14:24:00'),(20,'별사탕',10,'2024-01-17 14:24:00'),(21,'국화빵',11,'2024-01-17 14:24:00'),(22,'꼬치구이',11,'2024-01-17 14:24:00'),(23,'사각초콜릿',12,'2024-01-17 14:24:00'),(24,'아이스주스',12,'2024-01-17 14:24:00'),(25,'양상추',13,'2024-01-17 14:24:00'),(26,'복숭아',13,'2024-01-17 14:24:00'),(27,'왕고기구이',14,'2024-01-17 14:24:00'),(28,'꿀단지',14,'2024-01-17 14:24:00'),(29,'스테이크',15,'2024-01-17 14:24:00'),(30,'눈꽃빙수',15,'2024-01-17 14:24:00'),(31,'주먹밥',16,'2024-01-17 14:24:00'),(32,'블루레몬슬러시',16,'2024-01-17 14:24:00'),(33,'톡톡사탕',17,'2024-01-17 14:24:00'),(34,'밀크캐러멜',17,'2024-01-17 14:24:00'),(35,'레몬',18,'2024-01-17 14:24:00'),(36,'고래과자',18,'2024-01-17 14:24:00');
/*!40000 ALTER TABLE `master_food` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_gacha_reward`
--

DROP TABLE IF EXISTS `master_gacha_reward`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `master_gacha_reward` (
  `gacha_reward_key` int NOT NULL COMMENT '가챠 보상 키',
  `gacha_reward_name` varchar(50) DEFAULT NULL,
  `char_prob_percent` int NOT NULL COMMENT '캐릭터 확률 퍼센트',
  `skin_prob_percent` int NOT NULL COMMENT '스킨 확률 퍼센트',
  `costume_prob_percent` int NOT NULL COMMENT '코스튬 확률 퍼센트',
  `food_prob_percent` int NOT NULL COMMENT '푸드 확률 퍼센트',
  `food_gear_prob_percent` int NOT NULL COMMENT '푸드 기어 확률 퍼센트',
  `gacha_count` int NOT NULL COMMENT '가챠 개수',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  PRIMARY KEY (`gacha_reward_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='마스터 가챠 보상';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_gacha_reward`
--

LOCK TABLES `master_gacha_reward` WRITE;
/*!40000 ALTER TABLE `master_gacha_reward` DISABLE KEYS */;
INSERT INTO `master_gacha_reward` VALUES (1,'미니 상자',3,0,32,65,0,3,'2024-01-17 14:41:00'),(2,'일반 상자',3,0,32,65,0,8,'2024-01-17 14:41:00'),(3,'천국 상자',3,0,32,65,0,15,'2024-01-17 14:41:00');
/*!40000 ALTER TABLE `master_gacha_reward` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_gacha_reward_list`
--

DROP TABLE IF EXISTS `master_gacha_reward_list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `master_gacha_reward_list` (
  `gacha_reward_key` int NOT NULL COMMENT '가챠 보상 키',
  `reward_key` int NOT NULL COMMENT '보상 키',
  `reward_type` varchar(20) NOT NULL COMMENT '보상 종류',
  `reward_qty` int DEFAULT NULL,
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  PRIMARY KEY (`gacha_reward_key`,`reward_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='마스터 가챠 리스트';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_gacha_reward_list`
--

LOCK TABLES `master_gacha_reward_list` WRITE;
/*!40000 ALTER TABLE `master_gacha_reward_list` DISABLE KEYS */;
INSERT INTO `master_gacha_reward_list` VALUES (1,1,'char',1,'2024-01-17 14:45:00'),(1,2,'char',1,'2024-01-17 14:45:00'),(1,3,'char',1,'2024-01-17 14:45:00'),(1,4,'costume',1,'2024-01-17 14:45:00'),(1,5,'costume',1,'2024-01-17 14:45:00'),(1,6,'costume',1,'2024-01-17 14:45:00'),(1,7,'costume',1,'2024-01-17 14:45:00'),(1,8,'costume',1,'2024-01-17 14:45:00'),(1,9,'costume',1,'2024-01-17 14:45:00'),(1,10,'costume',1,'2024-01-17 14:45:00'),(1,11,'food',1,'2024-01-19 13:31:00'),(1,12,'food',1,'2024-01-19 13:31:00'),(1,13,'food',1,'2024-01-19 13:31:00'),(1,14,'food',1,'2024-01-19 13:31:00'),(1,15,'food',1,'2024-01-19 13:31:00'),(1,16,'food',1,'2024-01-19 13:31:00'),(1,17,'food',1,'2024-01-19 13:31:00'),(1,18,'food',1,'2024-01-19 13:31:00'),(2,1,'char',1,'2024-01-17 14:46:00'),(2,2,'char',1,'2024-01-17 14:46:00'),(2,3,'char',1,'2024-01-17 14:46:00'),(2,4,'costume',1,'2024-01-17 14:46:00'),(2,5,'costume',1,'2024-01-17 14:46:00'),(2,6,'costume',1,'2024-01-17 14:46:00'),(2,7,'costume',1,'2024-01-17 14:46:00'),(2,8,'costume',1,'2024-01-17 14:46:00'),(2,9,'costume',1,'2024-01-17 14:46:00'),(2,10,'costume',1,'2024-01-17 14:46:00'),(2,11,'food',1,'2024-01-19 13:32:00'),(2,12,'food',1,'2024-01-19 13:32:00'),(2,13,'food',1,'2024-01-19 13:32:00'),(2,14,'food',1,'2024-01-19 13:32:00'),(2,15,'food',1,'2024-01-19 13:32:00'),(2,16,'food',1,'2024-01-19 13:32:00'),(2,17,'food',1,'2024-01-19 13:32:00'),(2,18,'food',1,'2024-01-19 13:32:00'),(3,1,'char',1,'2024-01-17 14:46:00'),(3,2,'char',1,'2024-01-17 14:46:00'),(3,3,'char',1,'2024-01-17 14:46:00'),(3,4,'costume',1,'2024-01-17 14:46:00'),(3,5,'costume',1,'2024-01-17 14:46:00'),(3,6,'costume',1,'2024-01-17 14:46:00'),(3,7,'costume',1,'2024-01-17 14:46:00'),(3,8,'costume',1,'2024-01-17 14:46:00'),(3,9,'costume',1,'2024-01-17 14:46:00'),(3,10,'costume',1,'2024-01-17 14:46:00'),(3,11,'food',1,'2024-01-19 13:32:00'),(3,12,'food',1,'2024-01-19 13:32:00'),(3,13,'food',1,'2024-01-19 13:32:00'),(3,14,'food',1,'2024-01-19 13:32:00'),(3,15,'food',1,'2024-01-19 13:32:00'),(3,16,'food',1,'2024-01-19 13:32:00'),(3,17,'food',1,'2024-01-19 13:32:00'),(3,18,'food',1,'2024-01-19 13:32:00');
/*!40000 ALTER TABLE `master_gacha_reward_list` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_game`
--

DROP TABLE IF EXISTS `master_game`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `master_game` (
  `game_key` int NOT NULL COMMENT '게임 키',
  `game_name` varchar(20) NOT NULL,
  PRIMARY KEY (`game_key`),
  UNIQUE KEY `game_name` (`game_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_game`
--

LOCK TABLES `master_game` WRITE;
/*!40000 ALTER TABLE `master_game` DISABLE KEYS */;
INSERT INTO `master_game` VALUES (18,'건너건너'),(16,'날려날려'),(4,'날아날아'),(2,'넘어넘어'),(10,'높이높이'),(12,'놓아놓아'),(9,'달려달려'),(11,'돌아돌아'),(1,'뚫어뚫어'),(14,'뛰어말어'),(15,'무찔무찔'),(7,'미끌미끌'),(13,'붙어붙어'),(8,'빙글빙글'),(5,'뿌려뿌려'),(17,'뿌셔뿌셔'),(6,'어푸어푸'),(3,'올라올라');
/*!40000 ALTER TABLE `master_game` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_item_level`
--

DROP TABLE IF EXISTS `master_item_level`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `master_item_level` (
  `level` int NOT NULL COMMENT '레벨',
  `item_cnt` varchar(50) NOT NULL DEFAULT '1' COMMENT '아이템 개수',
  PRIMARY KEY (`level`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_item_level`
--

LOCK TABLES `master_item_level` WRITE;
/*!40000 ALTER TABLE `master_item_level` DISABLE KEYS */;
INSERT INTO `master_item_level` VALUES (1,'1'),(2,'2'),(3,'3'),(4,'5'),(5,'8'),(6,'12'),(7,'17'),(8,'23'),(9,'30'),(10,'38'),(11,'47');
/*!40000 ALTER TABLE `master_item_level` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_skill`
--

DROP TABLE IF EXISTS `master_skill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `master_skill` (
  `skill_key` int NOT NULL,
  `char_key` int DEFAULT NULL,
  `act_prob_percent` int NOT NULL COMMENT '발동 확률 퍼센트',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  PRIMARY KEY (`skill_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='마스터 스킬 테이블';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_skill`
--

LOCK TABLES `master_skill` WRITE;
/*!40000 ALTER TABLE `master_skill` DISABLE KEYS */;
INSERT INTO `master_skill` VALUES (1,1,4,'2024-01-15 10:45:00'),(2,2,4,'2024-01-15 10:45:00'),(3,3,7,'2024-01-15 10:45:00'),(4,0,6,'2024-01-15 10:45:00'),(5,0,4,'2024-01-15 10:45:00'),(6,0,5,'2024-01-15 10:45:00'),(7,0,4,'2024-01-15 10:45:00'),(8,0,3,'2024-01-15 10:45:00'),(9,0,4,'2024-01-15 10:45:00'),(10,0,3,'2024-01-15 10:45:00');
/*!40000 ALTER TABLE `master_skill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_skin`
--

DROP TABLE IF EXISTS `master_skin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `master_skin` (
  `skin_key` int NOT NULL,
  `skin_name` varchar(30) NOT NULL COMMENT '스킨 이름',
  `char_key` int NOT NULL,
  `skin_bonus_percent` int NOT NULL COMMENT '보너스 점수 퍼센트',
  `create_dt` datetime NOT NULL COMMENT '생성 일시',
  PRIMARY KEY (`skin_key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='마스터 스킨 테이블';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_skin`
--

LOCK TABLES `master_skin` WRITE;
/*!40000 ALTER TABLE `master_skin` DISABLE KEYS */;
INSERT INTO `master_skin` VALUES (1,'장난꾸러기 그리',1,20,'2024-01-15 11:22:00'),(2,'마법소녀 양군',2,20,'2024-01-15 11:22:00'),(3,'프로 아이돌 마카롱',3,30,'2024-01-15 11:22:00');
/*!40000 ALTER TABLE `master_skin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `version`
--

DROP TABLE IF EXISTS `version`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `version` (
  `app_version` varchar(10) NOT NULL,
  `master_data_version` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `version`
--

LOCK TABLES `version` WRITE;
/*!40000 ALTER TABLE `version` DISABLE KEYS */;
INSERT INTO `version` VALUES ('0.1','0.1');
/*!40000 ALTER TABLE `version` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'master_db'
--

--
-- Dumping routines for database 'master_db'
--

--
-- Current Database: `hive`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `hive` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `hive`;

--
-- Table structure for table `account_info`
--

DROP TABLE IF EXISTS `account_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `account_info` (
  `player_id` bigint NOT NULL AUTO_INCREMENT COMMENT '플레이어 아이디',
  `email` varchar(50) NOT NULL COMMENT '이메일',
  `salt_value` varchar(100) NOT NULL COMMENT '암호화 값',
  `pw` varchar(100) NOT NULL COMMENT '해싱된 비밀번호',
  `create_dt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '생성 일시',
  `recent_login_dt` datetime DEFAULT NULL COMMENT '최근 로그인 일시',
  PRIMARY KEY (`player_id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='계정 정보 테이블';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account_info`
--

LOCK TABLES `account_info` WRITE;
/*!40000 ALTER TABLE `account_info` DISABLE KEYS */;
INSERT INTO `account_info` VALUES (1,'abcbd@test.com','7xjgtaxv6oy4cc1c9a2gbdngy4u21xsjnl1k1q5wdxfuico831he2b0asjcvbvel','1be6032e2106d563f1c4c2c755cdc35b2bd3d46e2db8baabd0f6cfaa68d47d6f','2024-01-09 15:50:14','2024-01-09 15:50:14'),(3,'abcbd1@test.com','cztrgxat73701f8um9scj05fv9drnonotsdpzsuwigog4sr845cugmcr8a3pomhf','db885231eec979834eff6dcb0d4c3ec23caf2d147ffc34cae4887519810dc3a5','2024-01-09 16:02:56',NULL),(4,'abcbd1f@test.com','bnpgzhee4chepenj0ph5676lq1zb7no0x7lcayepbru46htvk045j6o56xirust1','4318d0ad61a7cdf863ba038a1e62d6d3af4cfc574a90de9317899650d3ee6b52','2024-01-10 18:11:31',NULL),(5,'abcbd1af@test.com','cyj53j66yhw4grwrdkg76e7f8dxzcsywhobs18fkm7x666z20xks5l3xa3bqsbc4','bbb9dd367b10d423559edc6b54b5e7e30b5c37133480c2f3db47340fe1daa994','2024-01-11 10:08:53',NULL),(6,'abcbd1afa@test.com','citaa2au5ozfdu12s19f7bq5l6o850hx40tkn13rzyrnqcjs4wm1l1zgrdjvbcjo','30e2dffd7ae45d8fd9e8075964cb41db4bbdbd09bf9d832bdbd507b3607fdaf6','2024-01-11 11:38:41',NULL),(7,'1@test.com','d1jkuen5v1m63lbspucd16wkkgnvvra31pm3tosxkgotatlcae2wkfrnpwkhduio','c0ba10b159476d10db60da1d071ea2404c35b7e4059b1ea81132eec24213aa2d','2024-01-11 16:34:11',NULL),(8,'2@test.com','574rsxatxgmubt08v4q8m5bpyc7w0pf6w9mtgno70ii0c6jwxxdhi2eyd465uujs','5a2c97fa6d5fecd108d4b6c5afcf002399a25b9476468e79f62e421c50967fd8','2024-01-11 16:36:05',NULL),(9,'3@test.com','e8nzu0qmc01wi4w15isec6dhshrqz4eol7gb5eztz2rzbitv5zbmypbxh15v1f0j','221801c871a495a52ea8a5bd4dc7b47d09e8b3fe19a54493a59d7f14abcfdd85','2024-01-11 16:43:01',NULL),(10,'4@test.com','tct86xtbfenfwlnnoz3nt035ifds4266i64po32gz2ufjewywausbdqnsbetq2b0','dc33fc3db50300636857f2810dbc89c0371f2b2207ee267146625306cd4d2dec','2024-01-11 16:45:47',NULL),(11,'5@test.com','olbyrf05b44io8rxgvv7umr40dh7rf8ehg0grh7zslql5o4lfdwk3oxrt7vfyu7v','589f7cb829828a62cd1f58290f5c202fc77a8683566ce36632588efbe1564ad4','2024-01-12 14:28:55',NULL),(12,'6@test.com','lsbhutl5m011f1s9xw9mn69fmanpel12b3trgr26cw7ne8auzvkqo74514mc7v3f','b7057c178f28ad2f24beb274f952a535e9088061ac4eac3801ab64005e2bf3c6','2024-01-12 14:46:49',NULL),(13,'7@test.com','v2iq9r4aepu0i0v8zsca3pdu81sm8wnbjuukcfhfhinnq2aff6toiv60za7tc2lb','b1d08dc7d1ff4711c929f9bb1c24937cad329994016d51ca95daa3f49118b03c','2024-01-12 15:16:42',NULL),(14,'8@test.com','a0dczgx8b31r504xewrpociycxno8zhs43sylq7yyot7l97rijtz9c2342tyegpf','fdbe82f08bdfcdcd4d2aaf5ab8162d2b28ab3bbc3b2305b4da4302ad6c615dd5','2024-01-15 16:34:31',NULL),(15,'9@test.com','pbyyd5nn94la951alwjtio4lrfty8ves0msdib28ftbgzqg3vtkrr422yajao1uq','a43e8f9951c98c7b071c356b045dd0c4b54c6fa2abb58d0a35c448ba2d86bf03','2024-01-15 16:48:22',NULL),(16,'10@test.com','0qfc57nse5jtdbcpa5ql27dhjnyv6x7w5zoz7sm6emr651uzkwir25ygxrazd5ao','1f1cede9c45f31736099ca11803c4280729e6e4fcf3e44157fbb72d5a6cc6ea4','2024-01-15 17:01:59',NULL),(17,'11@test.com','xbn9k66ubnjqdc6goxb6727rtala1pzrb2bufm5t0h2yg62de1hcjoo5x09y8lyd','7346084244c453dbcfe34a463b8bf9e82593b4009e76a6ca7f12273f13fb6148','2024-01-16 18:02:27',NULL),(18,'12@test.com','ri4l16cu087teyvv42ix569lyoapf5kcoa8voqhz2j1vpramwbki0atjo5n5o4cm','c699f38be380bba202cda4b350e54622537b581736da4e9954e3a30fcefdc622','2024-01-17 14:01:46',NULL),(19,'13@test.com','cswtuw26jhvcr4p1kd2icrknj3g66kb8c4yum98w452a289mgc10xl7re9gmjd35','474ae3ab870aaa44bf086e52d16707ce12dca6a686b28c421c8ea567b26325ae','2024-01-18 09:24:42',NULL),(20,'14@test.com','mkkyiu14g0f09e8kdxjpcbxuq4prodkg4b13da7b5afr3dco3gxzo70h7ifkb6ky','1f4982d1acdec357970db8794b908845e3a4454881e3761cb7f0b77237bfb8e6','2024-01-18 09:26:53',NULL),(21,'15@test.com','cuxc1pydhs8abbw59odhhe1umh74vdbxciucap0usm6hbyzklopny3qvmg1fkiob','b522af6ffb09fbba204eaaeba7f7b3f159c6f0d6d08b4ed20156a4ca695f69ad','2024-01-19 15:49:03',NULL),(22,'16@test.com','6kfdbrl43itnejewr0uxo9ad33j1nhgf3t0r8p9oapxlfxycl0tbmgi3v227hzds','36a1bf1fea5429e0a74d3908287eb4c336359330b79d45d5a6aaaf8ed30cad44','2024-01-22 17:50:12',NULL),(23,'17@test.com','7d5dbu6e59i4rff26ibmrgxyuchzka40lv281yfanbtnbciezgouzgvy098bit8x','b2da9a00d7ab138d7587112a8c4cd95fb554226d28d7bac077b656784d76fc55','2024-01-22 18:04:15',NULL),(24,'18@test.com','m4t3tplo3t3be3rrwkwhhlgpps7cctcdw50uc62wn7fx6mu47paqft16aew9swl4','eab65c03df4fc16f456dc0e08bb0871472464d7300389a4ba62dd3643ff6d202','2024-01-23 12:12:39',NULL),(25,'20@test.com','ws6djtig1cpzfyk2mp4iu3q586yba1q3taxbp6bcoqdi1uko26766u8tpd3ekqmc','e0b2f84691813f63387fd3fe1216ba4fcb550d252f6439623f886aaeaae91298','2024-01-23 17:34:24',NULL),(26,'19@test.com','4mjgbwe6k60s39v6n4kgmn8uatjyr7b3zuc3qa5t3eth9xs1unixu66s7x1pkwkv','c79cb909a362832be9832ba98ad610623481a786e61df751d3a864007a163c96','2024-01-23 17:34:30',NULL),(27,'0@test.com','yv81il8gw77tq86m2jtjulittxo3tcodqyc79lbr23mux90i0pnvbv084pkusxwe','6edb610cbbfb7c43ec58683ac8627f439f1c91c600a0b3807d547344046a214d','2024-01-24 11:10:58',NULL),(28,'a@test.com','xl1b4ao4p67fotl4csvw9p0c4egs3jvd8y90nataodc3cqirdkbw2oylbd3kv8ui','9b4a40ab304f3b931af89f9d2ffd023427c08206b871f89a0ca9203011ad41f3','2024-01-24 14:23:58',NULL),(29,'b@test.com','08zc4x7tubite7ryaps8r69o4gf7khavdn2mf342zo0z29i276n1arg9ssccegld','dd2ba6209f2f91ba6f3e90fd206aafa7dfcd9a5de4d9479f498dfc7f28dcb897','2024-01-24 14:28:11',NULL);
/*!40000 ALTER TABLE `account_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'hive'
--

--
-- Dumping routines for database 'hive'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-26 14:40:07
