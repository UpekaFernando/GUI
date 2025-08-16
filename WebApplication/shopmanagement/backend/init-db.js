const mysql = require('mysql2');
const dotenv = require('dotenv');
dotenv.config();

console.log('Database Initialization Script');
console.log('============================');

// Create connection without specifying database
const connection = mysql.createConnection({
  host: process.env.DB_HOST,
  user: process.env.DB_USER,
  password: process.env.DB_PASSWORD
});

// Create database if not exists
connection.query('CREATE DATABASE IF NOT EXISTS backend', (err) => {
  if (err) {
    console.error('Error creating database:', err);
    process.exit(1);
  }
  console.log('✓ Database "backend" created or already exists');
  
  // Switch to the database
  connection.query('USE backend', (err) => {
    if (err) {
      console.error('Error using database:', err);
      process.exit(1);
    }
    console.log('✓ Using database "backend"');
    
    // Create users table
    const createUsersTable = `
    CREATE TABLE IF NOT EXISTS users (
      id INT AUTO_INCREMENT PRIMARY KEY,
      email VARCHAR(255) UNIQUE NOT NULL,
      password VARCHAR(255) NOT NULL,
      role ENUM('user', 'shopkeeper') NOT NULL,
      shop_name VARCHAR(255),
      created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    )`;
    
    connection.query(createUsersTable, (err) => {
      if (err) {
        console.error('Error creating users table:', err);
        process.exit(1);
      }
      console.log('✓ Users table created or already exists');
      
      // Create menu_items table
      const createMenuItemsTable = `
      CREATE TABLE IF NOT EXISTS menu_items (
        id INT AUTO_INCREMENT PRIMARY KEY,
        shopkeeper_id INT NOT NULL,
        name VARCHAR(255) NOT NULL,
        description TEXT,
        price DECIMAL(10, 2) NOT NULL,
        created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
        FOREIGN KEY (shopkeeper_id) REFERENCES users(id) ON DELETE CASCADE
      )`;
      
      connection.query(createMenuItemsTable, (err) => {
        if (err) {
          console.error('Error creating menu_items table:', err);
          process.exit(1);
        }
        console.log('✓ Menu_items table created or already exists');
        
        // Create orders table
        const createOrdersTable = `
        CREATE TABLE IF NOT EXISTS orders (
          id INT AUTO_INCREMENT PRIMARY KEY,
          user_id INT NOT NULL,
          shopkeeper_id INT NOT NULL,
          menu_item_id INT NOT NULL,
          quantity INT NOT NULL DEFAULT 1,
          status ENUM('pending', 'completed', 'cancelled') DEFAULT 'pending',
          created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
          FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
          FOREIGN KEY (shopkeeper_id) REFERENCES users(id) ON DELETE CASCADE,
          FOREIGN KEY (menu_item_id) REFERENCES menu_items(id) ON DELETE CASCADE
        )`;
        
        connection.query(createOrdersTable, (err) => {
          if (err) {
            console.error('Error creating orders table:', err);
            process.exit(1);
          }
          console.log('✓ Orders table created or already exists');
          
          // Insert sample data (only if tables are empty)
          connection.query('SELECT COUNT(*) as count FROM users', (err, results) => {
            if (err) {
              console.error('Error checking users table:', err);
              process.exit(1);
            }
            
            if (results[0].count === 0) {
              console.log('⟳ Adding sample data...');
              
              // Add sample user
              connection.query(
                'INSERT INTO users (email, password, role) VALUES (?, ?, ?)',
                ['user@example.com', 'password123', 'user'],
                (err, result) => {
                  if (err) {
                    console.error('Error creating sample user:', err);
                  } else {
                    console.log('✓ Sample user created');
                  }
                  
                  // Add sample shopkeeper
                  connection.query(
                    'INSERT INTO users (email, password, role, shop_name) VALUES (?, ?, ?, ?)',
                    ['shop@example.com', 'password123', 'shopkeeper', 'Tasty Bites'],
                    (err, result) => {
                      if (err) {
                        console.error('Error creating sample shopkeeper:', err);
                      } else {
                        const shopkeeperId = result.insertId;
                        console.log('✓ Sample shopkeeper created');
                        
                        // Add sample menu items
                        connection.query(
                          'INSERT INTO menu_items (shopkeeper_id, name, description, price) VALUES (?, ?, ?, ?)',
                          [shopkeeperId, 'Burger', 'Delicious beef burger with cheese and lettuce', 9.99],
                          (err) => {
                            if (err) {
                              console.error('Error creating sample menu item 1:', err);
                            } else {
                              console.log('✓ Sample menu item 1 created');
                            }
                            
                            connection.query(
                              'INSERT INTO menu_items (shopkeeper_id, name, description, price) VALUES (?, ?, ?, ?)',
                              [shopkeeperId, 'Pizza', 'Pepperoni pizza with extra cheese', 12.99],
                              (err) => {
                                if (err) {
                                  console.error('Error creating sample menu item 2:', err);
                                } else {
                                  console.log('✓ Sample menu item 2 created');
                                }
                                
                                console.log('✓ Sample data added successfully!');
                                console.log('============================');
                                console.log('Database initialization complete!');
                                connection.end();
                              }
                            );
                          }
                        );
                      }
                    }
                  );
                }
              );
            } else {
              console.log('✓ Users table already has data, skipping sample data creation');
              console.log('============================');
              console.log('Database initialization complete!');
              connection.end();
            }
          });
        });
      });
    });
  });
});
