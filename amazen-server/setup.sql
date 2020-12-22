
-- CREATE TABLE colors (
--   id int AUTO_INCREMENT NOT NULL PRIMARY KEY,
--   color VARCHAR(255),
--   image VARCHAR(255)
-- -- )
-- CREATE TABLE products (
--   id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
--   title VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   image VARCHAR(255) NOT NULL,
--   size VARCHAR(255),
--   price DECIMAL (4,2) NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,
--   likes int,
--   dislikes int,
--   isAvailable TINYINT NOT NULL,
--   FOREIGN KEY (creatorId) REFERENCES profiles (id) ON DELETE CASCADE
-- )
  -- ALTER TABLE products
  -- ADD COLUMN colorId int NOT NULL
  -- drop TABLE products

-- CREATE TABLE wishlists (
--   id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
--   title VARCHAR(255),
--   creatorId int NOT NULL
-- )

-- drop table colors

-- create table wishlistProducts (
--   id int not null AUTO_INCREMENT PRIMARY KEY,
--   wishlistId int,
--   productId int,
--   creatorId VARCHAR(255) not null,
--   FOREIGN KEY (wishlistId)
--   REFERENCES wishlists (id)
--   ON DELETE CASCADE,
--   FOREIGN KEY (productId)
--   REFERENCES products (id)
--   ON DELETE CASCADE,
--   FOREIGN KEY (creatorId)
--   REFERENCES profiles (id)
--   ON DELETE CASCADE
-- )

-- ALTER TABLE  products
-- ADD COLUMN price DECIMAL(10,2),
-- ADD COLUMN image VARCHAR(500);

-- ALTER TABLE wishlists
-- drop COLUMN creatorId,
-- ADD COLUMN creatorId VARCHAR(255)
-- ADD COLUMN isPublished TINYINT
