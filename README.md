# Work Time Tracking System

The Work Time Tracking System is a Windows Forms application designed to help companies track and manage work hours for their projects. It provides a structured approach to recording employee work hours on specific tasks within various projects. The system maintains data about the company, its employees, projects, project tasks, and the time spent by employees on each task.

## Table of Contents

- [Features](#features)
- [Data Structure](#data-structure)
- [Usage](#usage)
- [Serialization](#serialization)

## Features

- **Company Information**: Input and update the company's name.
- **Employee Management**: Add, edit, and remove employee details.
- **Project Management**: Create, edit, and delete projects.
- **Task Management**: Define project tasks, update their details, and remove them.
- **Time Tracking**: Record and edit the time spent by employees on specific tasks (selecting employees from the company's list).
- **Data Serialization**: Save entered data in XML format to a file for future reference.
- **Data Deserialization**: Load previously saved data from a file for continued use.

## Data Structure

The system is structured according to the following data schema:

![image](https://github.com/vladislavv27/Darba_laika_uzskaite/assets/77066719/03941d4f-0a0b-423a-abe2-3476c6d974d1)

## Usage

1. Launch the application.
2. Enter the company's name.
3. Manage employees by adding, editing, or deleting their details.
4. Create, update, or delete projects.
5. Define project tasks and manage them.
6. Record employee work hours on specific tasks, selecting employees from the company's list.
7. Save entered data in XML format using the serialization feature.
8. Load previously saved data from a file using deserialization.

## Serialization

The system allows you to serialize the entered data in XML format, making it easy to save and retrieve company, employee, project, and task information. This feature ensures that your data remains accessible for future reference.
