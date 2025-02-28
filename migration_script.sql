CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "Parts" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Parts" PRIMARY KEY AUTOINCREMENT,
    "PartName" TEXT NULL,
    "PartNumber" TEXT NULL,
    "PartStatus" TEXT NULL,
    "PartCost" decimal(18, 2) NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250208210855_InitialCreate', '9.0.2');

CREATE TABLE "ef_temp_Parts" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Parts" PRIMARY KEY AUTOINCREMENT,
    "PartCost" decimal(18, 2) NULL,
    "PartName" TEXT NOT NULL,
    "PartNumber" TEXT NULL,
    "PartStatus" TEXT NOT NULL
);

INSERT INTO "ef_temp_Parts" ("Id", "PartCost", "PartName", "PartNumber", "PartStatus")
SELECT "Id", "PartCost", IFNULL("PartName", ''), "PartNumber", IFNULL("PartStatus", '')
FROM "Parts";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;
DROP TABLE "Parts";

ALTER TABLE "ef_temp_Parts" RENAME TO "Parts";

COMMIT;

PRAGMA foreign_keys = 1;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250208225736_NewDataAnnotations', '9.0.2');

BEGIN TRANSACTION;
CREATE TABLE "BuildLog" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_BuildLog" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NOT NULL,
    "Summary" TEXT NOT NULL,
    "Tag" TEXT NOT NULL,
    "Date" TEXT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250214125710_notecreation', '9.0.2');

DROP TABLE "KanbanTask";

CREATE TABLE "PriceComparison" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PriceComparison" PRIMARY KEY AUTOINCREMENT,
    "PartName" TEXT NOT NULL,
    "NewPrice" TEXT NOT NULL,
    "ActualPaidPrice" TEXT NOT NULL,
    "Source" TEXT NULL,
    "PurchaseDate" TEXT NOT NULL,
    "Notes" TEXT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250216002942_sqlite_migration_596', '9.0.2');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250216022351_addingtimelinetracking', '9.0.2');

CREATE TABLE "TimelineEntries" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TimelineEntries" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NOT NULL,
    "Notes" TEXT NULL,
    "Status" INTEGER NOT NULL,
    "Order" INTEGER NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250216022624_timelineupdate', '9.0.2');

DROP TABLE "TimelineEntries";

CREATE TABLE "BuildTasks" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_BuildTasks" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NOT NULL,
    "Description" TEXT NOT NULL,
    "Status" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250218031637_buildtrackermigration', '9.0.2');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250218032440_updatenames', '9.0.2');

ALTER TABLE "BuildTasks" ADD "PartsNeeded" INTEGER NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250218032826_fixedit', '9.0.2');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250218152636_partsaccquired', '9.0.2');

ALTER TABLE "BuildTasks" ADD "PartsAcquired" INTEGER NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250218152854_partsaccquiredagain', '9.0.2');

CREATE TABLE "SubTasks" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_SubTasks" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NOT NULL,
    "IsCompleted" INTEGER NOT NULL,
    "BuildTaskId" INTEGER NOT NULL,
    CONSTRAINT "FK_SubTasks_BuildTasks_BuildTaskId" FOREIGN KEY ("BuildTaskId") REFERENCES "BuildTasks" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_SubTasks_BuildTaskId" ON "SubTasks" ("BuildTaskId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250219000252_bigmigration', '9.0.2');

ALTER TABLE "BuildTasks" ADD "DependsOnTaskIds" TEXT NOT NULL DEFAULT '[]';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250219003936_changedatabasebackfromsubtasks', '9.0.2');

DROP TABLE "SubTasks";

ALTER TABLE "BuildTasks" RENAME COLUMN "DependsOnTaskIds" TO "Category";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250219013321_addingtags', '9.0.2');

COMMIT;

