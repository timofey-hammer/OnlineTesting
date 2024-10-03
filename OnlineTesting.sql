-- -------------------------------------------------------------
-- TablePlus 6.0.0(550)
--
-- https://tableplus.com/
--
-- Database: OnlineTesting
-- Generation Time: 2024-10-03 16:46:35.0310
-- -------------------------------------------------------------


-- This script only contains the table creation statements and does not fully represent the table in the database. Do not use it as a backup.

-- Table Definition
CREATE TABLE "public"."__EFMigrationsHistory" (
    "MigrationId" varchar(150) NOT NULL,
    "ProductVersion" varchar(32) NOT NULL,
    PRIMARY KEY ("MigrationId")
);

-- This script only contains the table creation statements and does not fully represent the table in the database. Do not use it as a backup.

-- Table Definition
CREATE TABLE "public"."Answers" (
    "AnswerId" int4 NOT NULL,
    "QuestionId" int4 NOT NULL,
    "Text" text NOT NULL,
    PRIMARY KEY ("AnswerId")
);

-- This script only contains the table creation statements and does not fully represent the table in the database. Do not use it as a backup.

-- Table Definition
CREATE TABLE "public"."Interviews" (
    "InterviewId" int4 NOT NULL,
    "InterviewerName" text NOT NULL,
    "DateCompleted" timestamptz,
    PRIMARY KEY ("InterviewId")
);

-- This script only contains the table creation statements and does not fully represent the table in the database. Do not use it as a backup.

-- Table Definition
CREATE TABLE "public"."Questions" (
    "QuestionId" int4 NOT NULL,
    "Text" text NOT NULL,
    "SurveyId" int4 NOT NULL,
    PRIMARY KEY ("QuestionId")
);

-- This script only contains the table creation statements and does not fully represent the table in the database. Do not use it as a backup.

-- Table Definition
CREATE TABLE "public"."Results" (
    "ResultId" int4 NOT NULL,
    "InterviewId" int4 NOT NULL,
    "QuestionId" int4 NOT NULL,
    "AnswerId" int4 NOT NULL,
    PRIMARY KEY ("ResultId")
);

-- This script only contains the table creation statements and does not fully represent the table in the database. Do not use it as a backup.

-- Table Definition
CREATE TABLE "public"."Surveys" (
    "SurveyId" int4 NOT NULL,
    "Title" text NOT NULL,
    "Description" text NOT NULL,
    "DateCreated" timestamptz NOT NULL,
    PRIMARY KEY ("SurveyId")
);

INSERT INTO "public"."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES
('20241003133309_InitialCreate', '8.0.8');

INSERT INTO "public"."Answers" ("AnswerId", "QuestionId", "Text") VALUES
(1, 1, 'Junior'),
(2, 1, 'Middle'),
(3, 1, 'Senior'),
(4, 2, 'Нет опыта'),
(5, 2, '1-3 года'),
(6, 2, '3-6 лет'),
(7, 3, 'Москва'),
(8, 3, 'Калининград'),
(9, 3, 'Санкт-Петербург'),
(10, 4, 'Офис'),
(11, 4, 'Гибрид'),
(12, 4, 'Удаленная работа');

INSERT INTO "public"."Questions" ("QuestionId", "Text", "SurveyId") VALUES
(1, 'Как вы себя оцениваете?', 1),
(2, 'Какой у вас опыт работы?', 1),
(3, 'В каком регионе вы проживаете?', 1),
(4, 'Какой формат работы вас интересует?', 1);

INSERT INTO "public"."Surveys" ("SurveyId", "Title", "Description", "DateCreated") VALUES
(1, 'Анкета при приеме на работу', 'Анкета для трудоустройства, чтобы получить дополнительные сведения о соискателе.', '2024-10-03 13:46:00.931263+00');



-- Indices
CREATE UNIQUE INDEX "PK___EFMigrationsHistory" ON public."__EFMigrationsHistory" USING btree ("MigrationId");
ALTER TABLE "public"."Answers" ADD FOREIGN KEY ("QuestionId") REFERENCES "public"."Questions"("QuestionId") ON DELETE CASCADE;


-- Indices
CREATE UNIQUE INDEX "PK_Answers" ON public."Answers" USING btree ("AnswerId");
CREATE INDEX "IX_Answers_QuestionId" ON public."Answers" USING btree ("QuestionId");


-- Indices
CREATE UNIQUE INDEX "PK_Interviews" ON public."Interviews" USING btree ("InterviewId");
CREATE INDEX "IX_Interviews_DateCompleted" ON public."Interviews" USING btree ("DateCompleted");
ALTER TABLE "public"."Questions" ADD FOREIGN KEY ("SurveyId") REFERENCES "public"."Surveys"("SurveyId") ON DELETE CASCADE;


-- Indices
CREATE UNIQUE INDEX "PK_Questions" ON public."Questions" USING btree ("QuestionId");
CREATE INDEX "IX_Questions_SurveyId" ON public."Questions" USING btree ("SurveyId");
ALTER TABLE "public"."Results" ADD FOREIGN KEY ("InterviewId") REFERENCES "public"."Interviews"("InterviewId") ON DELETE CASCADE;
ALTER TABLE "public"."Results" ADD FOREIGN KEY ("QuestionId") REFERENCES "public"."Questions"("QuestionId") ON DELETE CASCADE;
ALTER TABLE "public"."Results" ADD FOREIGN KEY ("AnswerId") REFERENCES "public"."Answers"("AnswerId") ON DELETE CASCADE;


-- Indices
CREATE UNIQUE INDEX "PK_Results" ON public."Results" USING btree ("ResultId");
CREATE INDEX "IX_Results_AnswerId" ON public."Results" USING btree ("AnswerId");
CREATE INDEX "IX_Results_InterviewId_QuestionId" ON public."Results" USING btree ("InterviewId", "QuestionId");
CREATE INDEX "IX_Results_QuestionId" ON public."Results" USING btree ("QuestionId");


-- Indices
CREATE UNIQUE INDEX "PK_Surveys" ON public."Surveys" USING btree ("SurveyId");
CREATE INDEX "IX_Surveys_DateCreated" ON public."Surveys" USING btree ("DateCreated");
