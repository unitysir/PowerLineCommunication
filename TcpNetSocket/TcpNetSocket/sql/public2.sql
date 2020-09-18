/*
 Navicat Premium Data Transfer

 Source Server         : pgTest
 Source Server Type    : PostgreSQL
 Source Server Version : 120004
 Source Host           : localhost:5432
 Source Catalog        : postgres
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 120004
 File Encoding         : 65001

 Date: 17/09/2020 21:24:06
*/


-- ----------------------------
-- Table structure for house_hold_meters
-- ----------------------------
DROP TABLE IF EXISTS "public"."house_hold_meters";
CREATE TABLE "public"."house_hold_meters" (
  "sn" varchar(10) COLLATE "pg_catalog"."default" NOT NULL,
  "comm_address" varchar(10) COLLATE "pg_catalog"."default",
  "rated_voltage" numeric(24),
  "meter_address" varchar(10) COLLATE "pg_catalog"."default",
  "line" varchar(10) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."house_hold_meters"."sn" IS '户表编号';
COMMENT ON COLUMN "public"."house_hold_meters"."comm_address" IS '户表通讯地址';
COMMENT ON COLUMN "public"."house_hold_meters"."rated_voltage" IS '户表额定电压';
COMMENT ON COLUMN "public"."house_hold_meters"."meter_address" IS '户表计量点地址';
COMMENT ON COLUMN "public"."house_hold_meters"."line" IS '该用户表用于那条线路';

-- ----------------------------
-- Table structure for line_meters
-- ----------------------------
DROP TABLE IF EXISTS "public"."line_meters";
CREATE TABLE "public"."line_meters" (
  "line" varchar(20) COLLATE "pg_catalog"."default" NOT NULL DEFAULT NULL::character varying,
  "sub_station_areas" varchar(40) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "location" varchar(40) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "terminal_sn" varchar(40) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying
)
;
COMMENT ON COLUMN "public"."line_meters"."line" IS '供电线路';
COMMENT ON COLUMN "public"."line_meters"."sub_station_areas" IS '台区名称，“如长马沟村1#公变';
COMMENT ON COLUMN "public"."line_meters"."location" IS '采集点地址';
COMMENT ON COLUMN "public"."line_meters"."terminal_sn" IS '该线路总表终端';

-- ----------------------------
-- Table structure for meter_data
-- ----------------------------
DROP TABLE IF EXISTS "public"."meter_data";
CREATE TABLE "public"."meter_data" (
  "meter_sn" varchar(40) COLLATE "pg_catalog"."default" NOT NULL DEFAULT NULL::character varying,
  "save_time" varchar COLLATE "pg_catalog"."default",
  "voltage_a" float4 NOT NULL,
  "voltage_b" float4,
  "voltage_c" float4,
  "current_a" float4 NOT NULL,
  "current_b" float4,
  "current_c" float4,
  "current_zero_line" float4,
  "current_remain" float4,
  "active_power_a" float4 NOT NULL,
  "active_power_b" float4,
  "active_power_c" float4,
  "active_power_total" float4,
  "reactive_power_a" float4,
  "reactive_power_b" float4,
  "reactive_power_c" float4,
  "reactive_power_total" float4,
  "power_factor_a" float4,
  "power_factor_b" float4,
  "power_factor_c" float4,
  "temperature" int2,
  "humidity" int2,
  "acquisition_time" varchar(20) COLLATE "pg_catalog"."default",
  "phase_fault_a" varchar(20) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "phase_fault_b" varchar(20) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "phase_fault_c" varchar(20) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "combined_phase_fault" varchar(20) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying
)
;
COMMENT ON COLUMN "public"."meter_data"."meter_sn" IS '电表编号；台变编号';
COMMENT ON COLUMN "public"."meter_data"."save_time" IS '保存时间';
COMMENT ON COLUMN "public"."meter_data"."voltage_a" IS 'A相电压';
COMMENT ON COLUMN "public"."meter_data"."voltage_b" IS 'B相电压';
COMMENT ON COLUMN "public"."meter_data"."voltage_c" IS 'C相电压';
COMMENT ON COLUMN "public"."meter_data"."current_a" IS 'A相电流';
COMMENT ON COLUMN "public"."meter_data"."current_b" IS 'B相电流';
COMMENT ON COLUMN "public"."meter_data"."current_c" IS 'C相电流';
COMMENT ON COLUMN "public"."meter_data"."current_zero_line" IS '零线电流';
COMMENT ON COLUMN "public"."meter_data"."current_remain" IS '剩余电流';
COMMENT ON COLUMN "public"."meter_data"."active_power_a" IS 'A相有功功率';
COMMENT ON COLUMN "public"."meter_data"."active_power_b" IS 'B相有功功率';
COMMENT ON COLUMN "public"."meter_data"."active_power_c" IS 'C相有功功率';
COMMENT ON COLUMN "public"."meter_data"."active_power_total" IS '总有功功率';
COMMENT ON COLUMN "public"."meter_data"."reactive_power_a" IS 'A相无功功率';
COMMENT ON COLUMN "public"."meter_data"."reactive_power_b" IS 'B相无功功率';
COMMENT ON COLUMN "public"."meter_data"."reactive_power_c" IS 'C相无功功率';
COMMENT ON COLUMN "public"."meter_data"."reactive_power_total" IS '总无功功率';
COMMENT ON COLUMN "public"."meter_data"."power_factor_a" IS 'A相功率因素';
COMMENT ON COLUMN "public"."meter_data"."power_factor_b" IS 'B相功率因素';
COMMENT ON COLUMN "public"."meter_data"."power_factor_c" IS 'C相功率因素';
COMMENT ON COLUMN "public"."meter_data"."temperature" IS '变压器温度（前端）/表箱内温度（后端），注意：前端不是总表）';
COMMENT ON COLUMN "public"."meter_data"."humidity" IS '湿度';
COMMENT ON COLUMN "public"."meter_data"."acquisition_time" IS '采集时间';
COMMENT ON COLUMN "public"."meter_data"."phase_fault_a" IS '运行状态字4（总表才有）';
COMMENT ON COLUMN "public"."meter_data"."phase_fault_b" IS '运行状态字5（总表才有）';
COMMENT ON COLUMN "public"."meter_data"."phase_fault_c" IS '运行状态字6（总表才有）';
COMMENT ON COLUMN "public"."meter_data"."combined_phase_fault" IS '运行状态字7（总表才有）';

-- ----------------------------
-- Table structure for power_line
-- ----------------------------
DROP TABLE IF EXISTS "public"."power_line";
CREATE TABLE "public"."power_line" (
  "line_sn" varchar(10) COLLATE "pg_catalog"."default" NOT NULL DEFAULT NULL::character varying,
  "line" varchar(20) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "department" varchar(20) COLLATE "pg_catalog"."default" NOT NULL DEFAULT NULL::character varying,
  "sub_station_areas" varchar(40) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "user" varchar(40) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying
)
;
COMMENT ON COLUMN "public"."power_line"."line_sn" IS '高压线路唯一编号';
COMMENT ON COLUMN "public"."power_line"."line" IS '供电线路说明，如“10KV铁光线”';
COMMENT ON COLUMN "public"."power_line"."department" IS '供电单位，如“盘龙供电锁”';
COMMENT ON COLUMN "public"."power_line"."sub_station_areas" IS '台区名称，“如长马沟村1#公变”';
COMMENT ON COLUMN "public"."power_line"."user" IS '用户名';

-- ----------------------------
-- Table structure for tb_test
-- ----------------------------
DROP TABLE IF EXISTS "public"."tb_test";
CREATE TABLE "public"."tb_test" (
  "id" int4 NOT NULL,
  "name" varchar(255) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Table structure for terminal
-- ----------------------------
DROP TABLE IF EXISTS "public"."terminal";
CREATE TABLE "public"."terminal" (
  "serial_number" int8 NOT NULL,
  "model" varchar(40) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "type" varchar(40) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "comm_protocol" varchar(40) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "comm_address" varchar(255) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "sim_number" int4,
  "rated_voltage" numeric(24),
  "location" varchar(255) COLLATE "pg_catalog"."default" DEFAULT ''::character varying,
  "department" varchar(20) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "line" varchar(20) COLLATE "pg_catalog"."default" NOT NULL DEFAULT NULL::character varying,
  "sub_station_areas" varchar(40) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "track_meter_sn" varchar(40) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "house_hold_meter_sn" varchar(40) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "sn" varchar(10) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."terminal"."serial_number" IS '终端资产编号，每个终端出厂时都由一个唯一编号';
COMMENT ON COLUMN "public"."terminal"."model" IS '终端型号';
COMMENT ON COLUMN "public"."terminal"."type" IS '终端类型';
COMMENT ON COLUMN "public"."terminal"."comm_protocol" IS '通讯规约';
COMMENT ON COLUMN "public"."terminal"."comm_address" IS '终端通讯地址';
COMMENT ON COLUMN "public"."terminal"."sim_number" IS 'SIM卡号(物联网卡)';
COMMENT ON COLUMN "public"."terminal"."rated_voltage" IS '额定电压';
COMMENT ON COLUMN "public"."terminal"."location" IS '采集点地址，如果没有使用，则为空';
COMMENT ON COLUMN "public"."terminal"."department" IS '供电单位，如果没有使用，则为空';
COMMENT ON COLUMN "public"."terminal"."line" IS '供电线路，该终端用于哪条线路，如果没有使用，则为空';
COMMENT ON COLUMN "public"."terminal"."sub_station_areas" IS '台区名称，如果没有使用，则为空';
COMMENT ON COLUMN "public"."terminal"."track_meter_sn" IS '该终端采集的总表编号';
COMMENT ON COLUMN "public"."terminal"."house_hold_meter_sn" IS '该终端采集的表箱编号';
COMMENT ON COLUMN "public"."terminal"."sn" IS '表的唯一编号';

-- ----------------------------
-- Table structure for truck_meters
-- ----------------------------
DROP TABLE IF EXISTS "public"."truck_meters";
CREATE TABLE "public"."truck_meters" (
  "sn" varchar(10) COLLATE "pg_catalog"."default" NOT NULL DEFAULT NULL::character varying,
  "comm_address" varchar(10) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "rated_voltage" int8 NOT NULL,
  "meter_address" varchar(10) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying,
  "ratio" numeric(10,1),
  "line_sn" varchar(10) COLLATE "pg_catalog"."default" DEFAULT NULL::character varying
)
;
COMMENT ON COLUMN "public"."truck_meters"."sn" IS '总表唯一编号';
COMMENT ON COLUMN "public"."truck_meters"."comm_address" IS '总表通讯地址';
COMMENT ON COLUMN "public"."truck_meters"."rated_voltage" IS '总表额定电压';
COMMENT ON COLUMN "public"."truck_meters"."meter_address" IS '总表计量点地址';
COMMENT ON COLUMN "public"."truck_meters"."ratio" IS '总表综合倍率';
COMMENT ON COLUMN "public"."truck_meters"."line_sn" IS '该总表用在那条线路';

-- ----------------------------
-- Primary Key structure for table house_hold_meters
-- ----------------------------
ALTER TABLE "public"."house_hold_meters" ADD CONSTRAINT "house_hold_meters_pkey" PRIMARY KEY ("sn");

-- ----------------------------
-- Primary Key structure for table line_meters
-- ----------------------------
ALTER TABLE "public"."line_meters" ADD CONSTRAINT "LineMeters_pkey" PRIMARY KEY ("line");

-- ----------------------------
-- Primary Key structure for table meter_data
-- ----------------------------
ALTER TABLE "public"."meter_data" ADD CONSTRAINT "meter_data_pkey" PRIMARY KEY ("meter_sn");

-- ----------------------------
-- Primary Key structure for table power_line
-- ----------------------------
ALTER TABLE "public"."power_line" ADD CONSTRAINT "powerline_pkey" PRIMARY KEY ("line_sn");

-- ----------------------------
-- Primary Key structure for table tb_test
-- ----------------------------
ALTER TABLE "public"."tb_test" ADD CONSTRAINT "tb_test_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table terminal
-- ----------------------------
ALTER TABLE "public"."terminal" ADD CONSTRAINT "Terminal_pkey" PRIMARY KEY ("serial_number");

-- ----------------------------
-- Primary Key structure for table truck_meters
-- ----------------------------
ALTER TABLE "public"."truck_meters" ADD CONSTRAINT "TruckMeters_pkey" PRIMARY KEY ("sn");
