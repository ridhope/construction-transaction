CREATE TABLE IF NOT EXISTS Users (
    UserID UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS Projects (
    ProjectID UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    ProjectName VARCHAR(200) NOT NULL,
    ProjectLocation VARCHAR(500) NOT NULL,
    ProjectStage VARCHAR(50) NOT NULL CHECK (ProjectStage IN ('Concept', 'Design & Documentation', 'Pre-Construction', 'Construction')),
    ProjectCategory VARCHAR(50) NOT NULL,
    OtherCategory VARCHAR(200),
    ConstructionStartDate DATE NOT NULL,
    ProjectDetails TEXT NOT NULL,
    ProjectCreatorID UUID NOT NULL,
    FOREIGN KEY (ProjectCreatorID) REFERENCES Users(UserID)
);

CREATE INDEX IF NOT EXISTS idx_project_creator ON Projects(ProjectCreatorID);

CREATE TABLE IF NOT EXISTS LoginHistoryRecord (
    LoginID UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    UserID UUID NOT NULL,
    LoginTimestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- username : admin
-- password : admin123

INSERT INTO public.users
(userid, username, passwordhash)
VALUES('554afc45-d2b8-4583-ac8d-b0afe83c4239'::uuid, 'admin', 'Y8oQsR/or0aOgb8w5crinA==.U8EfosgBjKoY0ViXV+ABH65+2Ay+nCxfkkPC94h/fhk=');


INSERT INTO Projects (
    ProjectID, ProjectName, ProjectLocation, ProjectStage, ProjectCategory, OtherCategory, ConstructionStartDate, ProjectDetails, ProjectCreatorID
) VALUES
(gen_random_uuid(), 'School Building', '123 Main St, Springfield', 'Concept', 'Education', 'Other', '2023-01-15', 'Project Detail', '554afc45-d2b8-4583-ac8d-b0afe83c4239'),
(gen_random_uuid(), 'Health Clinic', '456 Elm St, Springfield', 'Design & Documentation', 'Health', 'Other', '2023-02-20', 'Project Detail', '554afc45-d2b8-4583-ac8d-b0afe83c4239'),
(gen_random_uuid(), 'Corporate Office', '789 Oak St, Springfield', 'Pre-Construction', 'Office', 'Other', '2023-03-10', 'Project Detail', '554afc45-d2b8-4583-ac8d-b0afe83c4239'),
(gen_random_uuid(), 'Community Center', '101 Pine St, Springfield', 'Construction', 'Others', 'Community', '2023-04-05', 'Project Detail', '554afc45-d2b8-4583-ac8d-b0afe83c4239'),
(gen_random_uuid(), 'University Library', '202 Maple St, Springfield', 'Concept', 'Education', 'Other', '2023-05-12', 'Project Detail', '554afc45-d2b8-4583-ac8d-b0afe83c4239'),
(gen_random_uuid(), 'Hospital Expansion', '303 Cedar St, Springfield', 'Design & Documentation', 'Health', 'Other', '2023-06-18', 'Project Detail', '554afc45-d2b8-4583-ac8d-b0afe83c4239'),
(gen_random_uuid(), 'Tech Startup Office', '404 Birch St, Springfield', 'Pre-Construction', 'Office', 'Other', '2023-07-22', 'Project Detail', '554afc45-d2b8-4583-ac8d-b0afe83c4239'),
(gen_random_uuid(), 'Sports Complex', '505 Walnut St, Springfield', 'Construction', 'Others', 'Sports', '2023-08-30', 'Project Detail', '554afc45-d2b8-4583-ac8d-b0afe83c4239'),
(gen_random_uuid(), 'Research Lab', '606 Chestnut St, Springfield', 'Concept', 'Education', 'Other', '2023-09-15', 'Project Detail', '554afc45-d2b8-4583-ac8d-b0afe83c4239'),
(gen_random_uuid(), 'Dental Clinic', '707 Ash St, Springfield', 'Design & Documentation', 'Health', 'Other', '2023-10-25', 'Project Detail', '554afc45-d2b8-4583-ac8d-b0afe83c4239');